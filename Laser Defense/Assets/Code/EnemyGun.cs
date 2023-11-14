using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]Transform playerTransform;
    [SerializeField] Transform enemyTransform;
    [SerializeField] GameObject Lazer;
    [SerializeField] Transform Gun;
    bool canFire = true;
    AudioPlayer audioPlayer;

    void Awake(){
         audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Update(){
        EnemyFire();
    }

    void EnemyFire(){
    float playerX = Mathf.Ceil(playerTransform.position.x);
    float enemyX = Mathf.Ceil(enemyTransform.position.x);
    if (Mathf.Approximately(playerX, enemyX)){
         if(canFire == true){
          audioPlayer.PlayShootingClip();
          canFire = false;
          Instantiate(Lazer, Gun.position, transform.rotation);
         }
    }
}
}