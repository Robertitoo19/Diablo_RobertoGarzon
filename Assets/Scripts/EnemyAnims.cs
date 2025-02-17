using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnims : MonoBehaviour
{
    [SerializeField] private Enemy main;
    [SerializeField] NavMeshAgent agent;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);
    }
    public void DeathAnim()
    {
        anim.SetTrigger("Death");
    }
}
