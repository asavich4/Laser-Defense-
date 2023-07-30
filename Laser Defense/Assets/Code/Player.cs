using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    [SerializeField] float runSpeed = 5;

    [SerializeField] GameObject Lazer;
    [SerializeField] Transform Gun;

    [SerializeField] AudioClip shootSound;
    
    [SerializeField] float fireCooldown = 0.5f;
    private bool canFire = true;

    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        Bounds();
    }

    void Update(){
        Run();
        if (canFire && Input.GetButton("Fire1")){
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown(){
        canFire = false;
        Instantiate(Lazer, Gun.position, transform.rotation);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
        Destroy(collision.gameObject);
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
