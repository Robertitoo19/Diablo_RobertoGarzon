using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractable
{
    private Outline outline;

    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MissionSO mission;
    private void Awake()
    {
        outline = GetComponent<Outline>();
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
    private void OnMouseEnter() => outline.enabled = true;
    private void OnMouseExit() => outline.enabled = false;

}
