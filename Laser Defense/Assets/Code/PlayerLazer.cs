using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    Rigidbody2D myRigidbody2d;
    BoxCollider2D LazerBox;
    Animator myAnimator;
    Player player;
    float playerDirection;
    [SerializeField] float xArrow;
    [SerializeField] float yArrow;
    [SerializeField] GameObject deathPrefab;
    void Start(){
        myRigidbody2d = GetComponentInChildren<Rigidbody2D>();
        LazerBox = GetComponentInChildren<BoxCollider2D>();
        player = FindObjectOfType<Player>();
        myAnimator = GetComponent<Animator>();
        playerDirection = player.transform.localScale.x * yArrow;
    }

    void Update(){
        LazerMovement();
    }

    void LazerMovement(){
        myRigidbody2d.velocity = new Vector2(xArrow, playerDirection);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject deathHit = Instantiate(deathPrefab, transform.position, transform.rotation);
        }
    }
            
    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}



