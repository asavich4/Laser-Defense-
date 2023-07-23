using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave")]
public class WaveSO : ScriptableObject
{
    [SerializeField] Transform pathPreFab;
    [SerializeField] float moveSpeed;


    public Transform GetStartingWaypoint(){
        return pathPreFab.GetChild(0);
    }

    public List<Transform> GetWaypoints(){
        
    }
    public float GetMoveSpeed(){
        return moveSpeed;
    }

}
