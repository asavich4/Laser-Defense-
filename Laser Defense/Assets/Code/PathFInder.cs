using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFInder : MonoBehaviour
{
    [SerializeField] WaveSO waveSO;
    List<Transform> waypoints;
    int waypointIndex = 0;
    void Start(){
        waypoints = waveSO.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update(){
        FollowPath();
    }

    void FollowPath()
{
    if (waypointIndex < waypoints.Count){
        Vector3 targetPosition = waypoints[waypointIndex].position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        float maxDistanceDelta = waveSO.GetMoveSpeed() * Time.deltaTime;

        // Use Vector3.Lerp for smooth interpolation
        transform.position = Vector3.Lerp(transform.position, targetPosition, maxDistanceDelta / distanceToTarget);
        if (distanceToTarget <= maxDistanceDelta){
            waypointIndex++;
        }
    }
    else{
        Destroy(gameObject);
    }
}

}
