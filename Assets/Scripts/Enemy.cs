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



    void Start()
    {
        patroll.enabled = true;
    }
    void Update()
    {
        
    }
    public void ActiveCombat(Transform target) 
    {
        //Definir el target
        this.target = target;

        combat.enabled = true;
    }
    public void ActivePatroll()
    {
        combat.enabled = false;
        patroll.enabled = true;
    }
}
