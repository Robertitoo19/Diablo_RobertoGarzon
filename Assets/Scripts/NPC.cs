using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MissionSO missionNPC;
    [SerializeField] private DialogueSO myDialogueBefore;
    [SerializeField] private DialogueSO myDialogueAfter;
    [SerializeField] private float rotateDuration;
    [SerializeField] private Transform cameraPoint; //punto camara de cada npc.

    private DialogueSO actualDialogue;

    private void Awake()
    {
        actualDialogue = myDialogueBefore;
    }
    private void OnEnable()
    {
        eventManager.OnNoMission += ChangeDialogue;
    }
    private void OnDisable()
    {
        eventManager.OnNoMission -= ChangeDialogue;
    }
    private void ChangeDialogue(MissionSO missionFinish)
    {
        if (missionNPC == missionFinish)
        {
            actualDialogue = myDialogueAfter;
        }
    }

    private void StartInteraction()
    {
        DialogueSystem.System.StartDialogue(actualDialogue, cameraPoint);
    }

    public void interact(Transform interactor)
    {
        //rota hacia el interactuador y cuando termine se inicia la interaccion.
        transform.DOLookAt(interactor.position, rotateDuration, AxisConstraint.Y).OnComplete(StartInteraction);
    }
}
