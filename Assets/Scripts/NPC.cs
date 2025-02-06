using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MissionSO missionNPC;
    [SerializeField] private DialogueSO myDialogueBefore;
    [SerializeField] private DialogueSO myDialogueAfter;
    [SerializeField] private float rotateDuration;
    [SerializeField] private Transform cameraPoint; //punto camara de cada npc.

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;

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
    private void OnMouseEnter()
    {
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
    }
}
