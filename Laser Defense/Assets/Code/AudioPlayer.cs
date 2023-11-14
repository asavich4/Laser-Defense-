using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  [Header ("Shooting")]
  [SerializeField] AudioClip shootingClip;
  [SerializeField] [Range(0 , 1)] float shootingVolume = 1;

  [Header ("Death")]
  [SerializeField] AudioClip deathSound;
  [SerializeField] [Range(0 , 1)] float deathVolume = 1;

  public void PlayShootingClip(){
    if(shootingClip != null){
        AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
    }
  }

   public void PlayDeathClip(){
    if(shootingClip != null){
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
    }
  }
}
