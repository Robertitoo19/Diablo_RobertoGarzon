
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolSystem : MonoBehaviour
{
    [SerializeField] private Enemy main;

    [SerializeField] private Transform route;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float patrollVelocity;

    private List<Vector3> pointLists = new List<Vector3>();
    //indice del punto
    private int actualIndexDestination = -1;
    //punto donde debo ir
    private Vector3 actualDestination; 
    private void Awake()
    {
        //decirle al script principal que soy el sistema de patrulla
        main.Patroll = this;
        foreach (Transform point in route)
        {
            pointLists.Add(point.position);
        }
    }
    void Start()
    {
    }
    private void OnEnable()
    {
        agent.stoppingDistance = 0;
        agent.speed = patrollVelocity;
        StartCoroutine(PatrollAndWait());
    }
    void Update()
    {
        
    }
    private IEnumerator PatrollAndWait()
    {
        while (true)
        {
            CalculateDestination();
            agent.SetDestination(actualDestination);
            //expresion Lambda (metodo anonimo)
            yield return new WaitUntil(() => agent.remainingDistance <= 0);

            yield return new WaitForSeconds(Random.Range(0.25f, 2f));
        }
    }

    private void CalculateDestination()
    {
        //cambiar de punto
        actualIndexDestination++;

        if (actualIndexDestination >= pointLists.Count)
        {
            actualIndexDestination = 0;
        }

        actualDestination = pointLists[actualIndexDestination];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //paramos la corrutina de patrulla
            StopAllCoroutines();
            //activar el combate e ir a por el target
            main.ActiveCombat(other.transform);
        }
    }
}
