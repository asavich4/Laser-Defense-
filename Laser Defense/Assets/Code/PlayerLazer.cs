using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLazer : MonoBehaviour
{
    Rigidbody2D myRigidbody2d;
    BoxCollider2D LazerBox;
    Player player;
    float playerDirection;
    [SerializeField] float xArrow;
    [SerializeField] float yArrow;
    ScoreKeeper scoreKeeper;
    void Start(){
        myRigidbody2d = GetComponentInChildren<Rigidbody2D>();
        LazerBox = GetComponentInChildren<BoxCollider2D>();
        player = FindObjectOfType<Player>();
        playerDirection = player.transform.localScale.x * yArrow;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
            scoreKeeper.ModifyScore(100);
        }
    }
            
    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}

