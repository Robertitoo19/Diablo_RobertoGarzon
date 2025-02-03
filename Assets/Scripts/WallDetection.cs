using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    [SerializeField] private float transitionTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Material wallMaterial = other.GetComponent<MeshRenderer>().material;
            Color transparent = new Color(wallMaterial.color.r, wallMaterial.color.g, wallMaterial.color.b, 0.25f);
            wallMaterial.DOColor(transparent, transitionTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Material wallMaterial = other.GetComponent<MeshRenderer>().material;
            Color opaque = new Color(wallMaterial.color.r, wallMaterial.color.g, wallMaterial.color.b, 1f);
            wallMaterial.DOColor(opaque, transitionTime);
        }
    }
}
