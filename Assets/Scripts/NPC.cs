using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float rotateDuration;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Interact(Transform interactuator)
    {
        transform.DOLookAt(interactuator.position, rotateDuration, AxisConstraint.Y);
    }
}
