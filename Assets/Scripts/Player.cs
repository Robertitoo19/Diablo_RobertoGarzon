using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, Idamagable
{
    [SerializeField] private float lifes;
    [SerializeField] private float attackingDistance;
    [SerializeField] private float attackDamage;
    [SerializeField] private float interactDistance;
    [SerializeField] private Image healthBar;

    private Camera cam;
    private NavMeshAgent agent;
    //ultimo sitio dnd cliqué con el raton.
    private Transform lastHit;

    private Transform currentTarget;
    private PlayerVisual playerVisual;

    private float actualLifes;

    public PlayerVisual PlayerVisual { get => playerVisual; set => playerVisual = value; }

    private void Awake()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        actualLifes = lifes;
    }
    void Update()
    {
        Movement();
        CheckInteract();
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //crear rayo desde la cam a la pos del raton.
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //si el rayo impacta.
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //vas pa ya. Destino el punto impacto del rayo.
                agent.SetDestination(hitInfo.point);
                //actualizar ultimo hit dnd he clicado.
                lastHit = hitInfo.transform;
            }
        }
    }
    private void CheckInteract()
    {
        if (lastHit)
        {
            playerVisual.StopAttacking();
            //si hay ultimo hit y tiene el script npc.
            if (lastHit.TryGetComponent(out IInteractable interactable))
            {
                //actualiza distancia de parada.
                agent.stoppingDistance = interactDistance;
                //si hemos llegado al destino.
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    interactable.interact(transform);
                    //borramos el historial del ultimo click
                    lastHit = null;
                }
            }
            //si no es un npc
            else if (lastHit.TryGetComponent(out Idamagable damage))
            {
                currentTarget = lastHit;
                agent.stoppingDistance = attackingDistance;
                if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    playerVisual.StartAttacking();
                }
            }
            else
            {
                agent.stoppingDistance = 0;
            }
        }
    }
    public void Attack()
    {
        if(currentTarget != null)
        {
            currentTarget.GetComponent<Idamagable>().ReceiveDamage(attackDamage);
        }
    }
    public void ReceiveDamage(float enemyDamage)
    {
        actualLifes -= enemyDamage;
        healthBar.fillAmount = actualLifes / lifes;
        if (actualLifes <= 0)
        {
            Destroy(this);
            playerVisual.DeathAnim();
        }
    }
}
