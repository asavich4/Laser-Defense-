using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    [SerializeField]Transform playerTransform;
    [SerializeField] Transform enemyTransform;
    [SerializeField] GameObject Lazer;
    [SerializeField] Transform Gun;
    [SerializeField] float fireCooldown = 3f;
    bool canFire;

    void Update(){
        EnemyFire();
    }

    void EnemyFire(){
    float playerX = Mathf.Ceil(playerTransform.position.x);
    float enemyX = Mathf.Ceil(enemyTransform.position.x);


    if (Mathf.Approximately(playerX, enemyX)){
        Debug.Log("Player and enemy have the same X-axis position.");
         if (canFire){
            StartCoroutine(FireCooldown());
        }
    }
}
IEnumerator FireCooldown(){
        canFire = false;
        Instantiate(Lazer, Gun.position, transform.rotation);
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }


}
