using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector2 maxBounds;
    Vector2 minBounds;
    [SerializeField] float padLeft;
    [SerializeField] float padRight;
    [SerializeField] float padBottom;
    [SerializeField] float padTop;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    SpriteRenderer playerSpriteRenderer;

    [SerializeField] float runSpeed = 5;

    [SerializeField] GameObject Lazer;
    [SerializeField] Transform Gun;

    [SerializeField] AudioClip shootSound;
    
    [SerializeField] float fireCooldown = 0.5f;
    private bool canFire = true;
    [SerializeField] int lives = 3;

    [SerializeField] float flashTimerReset = 1f;
    [SerializeField] float flashTimer = 1f;
    public bool isFlashing = false;
    [SerializeField] GameObject deathPrefab; 
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    void Awake(){
         cameraShake = Camera.main.GetComponent<CameraShake>();
         audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        Bounds();
    }

    void Update(){
        Run();
        playerFlash();
        if (canFire && Input.GetButton("Fire1")){
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown(){
        canFire = false;
        Instantiate(Lazer, Gun.position, transform.rotation);
        //AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
        audioPlayer.PlayShootingClip();
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D other){
    if(isFlashing == false){ 
        if (other.CompareTag("Enemy")){
            lives--;
            shakeCamera();
            audioPlayer.PlayDeathClip();
            if(lives <= 0){
                Destroy(gameObject);
                GameObject deathHit = Instantiate(deathPrefab, transform.position, transform.rotation);
                    }
            else{
                isFlashing = true;
            }
        }
    }
    }

    public void playerFlash(){
        if (isFlashing){
            flashTimer -= Time.deltaTime;
            if(flashTimer > 0){
                playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;
            }
                else if(flashTimer <= 0f){
                    isFlashing = false;
                    flashTimer = flashTimerReset;
                }
        }
        else{
            playerSpriteRenderer.enabled = true;
        }
    }

    void shakeCamera(){
        if(cameraShake != null && applyCameraShake){
            cameraShake.Play();
        }
    }

    void Run(){
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed * Time.deltaTime, moveInput.y * runSpeed * Time.deltaTime);
        myRigidbody.velocity = playerVelocity;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + playerVelocity.x, minBounds.x + padLeft, maxBounds.x - padRight);
        newPos.y = Mathf.Clamp(transform.position.y + playerVelocity.y, minBounds.y + padBottom, maxBounds.y - padTop);
        transform.position = newPos;
    }

    void Bounds(){
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
