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
        eventManager.OnUpdateMission += UpdateToggleMission;
        eventManager.OnNoMission += FinishToggleMission;
    }
    private void OnDisable()
    {
        eventManager.OnNewMission -= TurnOnToggleMission;
        eventManager.OnUpdateMission -= UpdateToggleMission;
        eventManager.OnNoMission -= FinishToggleMission;
    }

    private void TurnOnToggleMission(MissionSO mission)
    {
        //texto con el contenido de la misiom
        missionToggles[mission.missionIndex].MissionText.text = mission.inicialmessage;
        //si tiene repeticion
        if (mission.hasrepetition)
        {
            missionToggles[mission.missionIndex].MissionText.text += " (" + mission.actualRepetition + " / " + mission.totalRepetitions + ")";
        }
        //endender toggle para q se vea en pantalla
        missionToggles[mission.missionIndex].gameObject.SetActive(true);   
    }
    private void UpdateToggleMission(MissionSO mission)
    {
        missionToggles[mission.missionIndex].MissionText.text = mission.inicialmessage;
        missionToggles[mission.missionIndex].MissionText.text += " (" + mission.actualRepetition + " / " + mission.totalRepetitions + ")";
    }
    private void FinishToggleMission(MissionSO mission)
    {
        //poner el tick en true
        missionToggles[mission.missionIndex].ToggleVisual.isOn = true;
        //poner texto de conseguido
        missionToggles[mission.missionIndex].MissionText.text = mission.finalmessage;
    }


}
