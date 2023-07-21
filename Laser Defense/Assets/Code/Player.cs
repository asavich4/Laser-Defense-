using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    [SerializeField] float runSpeed = 5;

    [SerializeField] GameObject Lazer;
    [SerializeField]Transform Gun;
    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

 
    void Update(){
        Run();
    }

     void OnFire(InputValue value){
        Instantiate(Lazer, Gun.position, transform.rotation);
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

     void Run(){
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, moveInput.y * runSpeed);
        myRigidbody.velocity = playerVelocity;
    }
}
