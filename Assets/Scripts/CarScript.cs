using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarScript : MonoBehaviour
{
    [SerializeField] private Core core;

     public void OnTriggerEnter2D(Collider2D other) 
    {
        transform.DOKill();
        core.CarCrash();
    }
}
