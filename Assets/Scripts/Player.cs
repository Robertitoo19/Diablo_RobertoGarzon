using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    //ultimo sitio dnd cliqué con el raton.
    private Transform lastHit;
    [SerializeField] private float interactDistance;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
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
        //si hay ultimo hit y tiene el script npc.
        if (lastHit != null && lastHit.TryGetComponent(out NPC scriptNPC))
        {
            //actualiza distancia de parada.
            agent.stoppingDistance = interactDistance;
            //si hemos llegado al destino.
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                scriptNPC.Interact(transform);
                //borramos el historial del ultimo click
                lastHit = null;
            }
        }
        //si no es un npc
        else if (lastHit)
        {
            agent.stoppingDistance = 0f;
        }
    }
}
