using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueSO myDialogue;
    [SerializeField] private float rotateDuration;
    [SerializeField] private Transform cameraPoint; //punto camara de cada npc.
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Interact(Transform interactuator)
    {
        //rota hacia el interactuador y cuando termine se inicia la interaccion.
        transform.DOLookAt(interactuator.position, rotateDuration, AxisConstraint.Y).OnComplete(StartInteraction);
    }
    private void StartInteraction()
    {
        DialogueSystem.System.StartDialogue(myDialogue, cameraPoint);
    }
}
