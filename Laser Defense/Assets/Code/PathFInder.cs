using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInder : MonoBehaviour
{

    Spawner enemySpawner;
    WaveSO waveSO;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() {
        enemySpawner = FindObjectOfType<Spawner>();
    }
    void Start(){
        waveSO = enemySpawner.GetCurrentWave();
        waypoints = waveSO.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update(){
        FollowPath();
    }

    void FollowPath(){
    if (waypointIndex < waypoints.Count){
        Vector3 targetPosition = waypoints[waypointIndex].position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        float maxDistanceDelta = waveSO.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPosition, maxDistanceDelta / distanceToTarget);
        if (distanceToTarget <= maxDistanceDelta){
            waypointIndex++;
        }
    }
    else{
        Destroy(gameObject);
    }
}
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }

}
