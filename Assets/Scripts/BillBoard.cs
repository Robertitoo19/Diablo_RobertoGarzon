using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        transform.forward = -cam.transform.forward;
    }
}