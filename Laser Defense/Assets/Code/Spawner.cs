using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    [SerializeField] List<WaveSO> waveSOs;
    [SerializeField] float timeBetweenWaveSpawns = 0.5f;
    [SerializeField] bool isLooping = true;
     WaveSO currentWave;

    void Start(){
        StartCoroutine(Spawn());
    }

    public WaveSO GetCurrentWave(){
        return currentWave;
    }
     IEnumerator Spawn(){
        do{
        foreach(WaveSO wave in waveSOs){
        currentWave = wave;    
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        yield return new WaitForSeconds(timeBetweenWaveSpawns);
        }
     }
    
    while(isLooping);
    
}
}

