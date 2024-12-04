using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //crear rayo desde la cam a la pos del raton.
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //si el rayo impacta.
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //vas pa ya. Destino el punto impacto del rayo
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}
