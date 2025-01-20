using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Player Player;

    private Vector3 distanceToPlayer;
    void Start()
    {
        //calcular distancia que hay de la camara al player
        distanceToPlayer = transform.position - Player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = Player.transform.position + distanceToPlayer;
    }
}
