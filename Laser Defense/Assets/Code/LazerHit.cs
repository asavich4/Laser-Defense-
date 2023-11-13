using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerHit : MonoBehaviour
{
    [SerializeField] float DeathTime = 1.0f;
    void Start(){
        StartCoroutine(DestroyPlayer(gameObject));
    }
    
IEnumerator DestroyPlayer(GameObject deathPrefab){
        yield return new WaitForSeconds(DeathTime);
        Destroy(gameObject);
    }
}
