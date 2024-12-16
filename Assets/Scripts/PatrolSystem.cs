using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolSystem : MonoBehaviour
{
    [SerializeField] private Transform route;

    private List<Transform> pointLists = new List<Transform>();
    void Start()
    {
        foreach (Transform point in route)
        {
            
        }
    }
    void Update()
    {
        
    }
}
