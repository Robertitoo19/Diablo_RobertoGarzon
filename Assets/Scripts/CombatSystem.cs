using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float combatVelocity;

    private void Awake()
    {
        main.Combat = this;
    }
    //cuando se active
    private void OnEnable()
    {
        agent.speed = combatVelocity;
    }
    private void Update()
    {
        //Seguir al target todo el rato
        agent.SetDestination(main.Target.position);
    }
}
