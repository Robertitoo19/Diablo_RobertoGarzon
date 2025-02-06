using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Jobs;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private Enemy main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float combatVelocity;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackDamage;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        main.Combat = this;
    }
    //cuando se active
    private void OnEnable()
    {
        agent.speed = combatVelocity;
        agent.stoppingDistance = attackDistance;
    }
    private void Update()
    {
        //si existe un objetivo y tiene el camino para llegar
        if (main.Target != null && agent.CalculatePath(main.Target.position, new NavMeshPath())) 
        {
            //siempre enfocar objetivo
            AimObjetive();

            //Seguir al target todo el rato
            agent.SetDestination(main.Target.position);

            //cuando el objetivo este a distancia de ataque
            if(!agent.pathPending && agent.remainingDistance <= attackDistance)
            {
                anim.SetBool("IsAttacking", true);
            }
        }
        else
        {
            main.ActivePatroll();
        }
    }

    private void AimObjetive()
    {
        //calcular direccion al objetivo
        Vector3 targetDireccion = (main.Target.position - transform.position).normalized;
        //y a 0 para no volcar
        targetDireccion.y = 0;
        //transformar direccion en rotacion
        Quaternion targetRotation = Quaternion.LookRotation(targetDireccion);
        //aplicar rotacion
        transform.rotation = targetRotation;
    }
    public void Attack()
    {
        main.Target.GetComponent<Idamagable>().ReceiveDamage(attackDamage);
    }
    #region Ejecutados por evento de animacion
    private void AttackAnim()
    {
        anim.SetBool("IsAttacking", true);
    }
    private void EndAttackAnim()
    {
        anim.SetBool("IsAttacking", false);
    }
    #endregion
}
