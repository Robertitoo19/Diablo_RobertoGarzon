using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MissionToggle[] missionToggles;

    private void OnEnable()
    {
        //suscribirse al evento y vincular al metodo
        eventManager.OnNewMission += TurnOnToggleMission;
    }

    private void TurnOnToggleMission(MissionSO mission)
    {
        togg   
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
