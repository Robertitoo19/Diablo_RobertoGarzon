using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractable
{
    private Outline outline;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;

    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MissionSO mission;

    [SerializeField] private Riddle riddle;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    public void interact(Transform interactor)
    {
        riddle.ShowRiddle();
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
        outline.enabled = true;
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
    }
}
