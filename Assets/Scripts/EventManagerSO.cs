using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MissionSO> OnNewMission;
    public event Action<MissionSO> OnUpdateMission;
    public event Action<MissionSO> OnNoMission;
    public void NewMission(MissionSO mission)
    {
        //notificar evento con parametro de entrada
        OnNewMission?.Invoke(mission);
    }

    public void UpdateMission(MissionSO mission)
    {
        OnUpdateMission?.Invoke(mission);
    }
    public void FinishMission(MissionSO mission) 
    {
        OnNoMission?.Invoke(mission); 
    }
}
