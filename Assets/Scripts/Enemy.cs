using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PatrolSystem patroll;
    private CombatSystem combat;

    private Transform target;

    public PatrolSystem Patroll { get => patroll; set => patroll = value; }
    public CombatSystem Combat { get => combat; set => combat = value; }
    public Transform Target { get => target; set => target = value; }

    public void ActiveCombat(Transform target) 
    {
        patroll.enabled = false;
        combat.enabled = true;
        //Definir el target
        this.target = target;
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
