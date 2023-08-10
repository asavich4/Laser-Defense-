using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLazer : MonoBehaviour
{
 [SerializeField] float speed = 5f;

    void Update(){
        Vector3 movement = new Vector3(0f, -speed * Time.deltaTime, 0f);
        transform.position += movement;

        // Destroy the laser when it goes off-screen
        if (transform.position.y < -10f){
            Destroy(gameObject);
        }
    }
}