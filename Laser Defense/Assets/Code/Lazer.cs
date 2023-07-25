using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    Rigidbody2D myRigidbody2d;
    BoxCollider2D LazerBox;
    Player player;
    float playerDirection;
    [SerializeField] float xArrow;
    [SerializeField] float yArrow;
    [SerializeField] AudioClip shootSound;
    void Start(){
        myRigidbody2d = GetComponentInChildren<Rigidbody2D>();
        LazerBox = GetComponentInChildren<BoxCollider2D>();
        player = FindObjectOfType<Player>();
        playerDirection = player.transform.localScale.x * yArrow;
         AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
    }

    void Update(){
        LazerMovement();
    }

    void LazerMovement(){
        myRigidbody2d.velocity = new Vector2(xArrow, playerDirection);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
