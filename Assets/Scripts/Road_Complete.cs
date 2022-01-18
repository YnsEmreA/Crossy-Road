using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Complete : MonoBehaviour
{
    [SerializeField] private Core core;

    public void OnTriggerEnter2D(Collider2D other) 
    {
        core.CompleteRoad();
    }
}
