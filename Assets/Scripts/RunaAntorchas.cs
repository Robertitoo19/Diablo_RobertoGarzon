using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaAntorchas : MonoBehaviour, IInteractable
{

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;

    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MissionSO mission;

    private Outline outline;
    private Collider coll;
    private void Awake()
    {
        outline = GetComponent<Outline>();
        coll = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        TorchPuzzle.OnCorrectSecuence += ActiveObject;
    }
    private void OnDisable()
    {
        TorchPuzzle.OnCorrectSecuence -= ActiveObject;
    }

    private void ActiveObject()
    {
        coll.enabled = true;
    }

    public void interact(Transform interactor)
    {
        //aumentar la repeticion
        mission.actualRepetition++;

        //todavia quedan setas por recoger
        if (mission.actualRepetition < mission.totalRepetitions)
        {
            eventManager.UpdateMission(mission);
        }
        //se han cogido todas
        else
        {
            eventManager.FinishMission(mission);
        }
        Destroy(gameObject);
    }
    private void OnMouseEnter()
    {
        if (coll.enabled)
        {
            outline.enabled = true;
            Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
        }
    }
    private void OnMouseExit()
    {
        if (coll.enabled)
        {
            outline.enabled = false;
            Cursor.SetCursor(default, Vector2.zero, CursorMode.Auto);
        }
    }
}
