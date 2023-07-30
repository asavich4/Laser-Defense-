using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave")]
public class WaveSO : ScriptableObject
{
    [SerializeField] List <GameObject> enemyPrefabs;
    [SerializeField] Transform pathPreFab;
    [SerializeField] float moveSpeed;

    public int GetEnemyCount(){
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index){
        return enemyPrefabs[index];
    }
    public Transform GetStartingWaypoint(){
        return pathPreFab.GetChild(0);
    }

    public List<Transform> GetWaypoints(){
        List<Transform> waypoint = new List<Transform>();
        foreach(Transform child in pathPreFab){
            waypoint.Add(child);
        }
        return waypoint;
    }
    public float GetMoveSpeed(){
        return moveSpeed;
    }

}
