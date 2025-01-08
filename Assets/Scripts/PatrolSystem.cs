
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolSystem : MonoBehaviour
{
    [SerializeField] private Transform route;
    [SerializeField] private NavMeshAgent agent;

    private List<Vector3> pointLists = new List<Vector3>();
    //indice del punto
    private int actualIndexDestination = -1;
    //punto donde debo ir
    private Vector3 actualDestination; 
    private void Awake()
    {
        foreach (Transform point in route)
        {
            pointLists.Add(point.position);
        }
    }
    void Start()
    {
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
}
