using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MissionSO> OnNewMission;
    public event Action OnNoMission;
    public void NewMission(MissionSO mission)
    {
        //notificar evento con parametro de entrada
        OnNewMission?.Invoke(mission);
    }
}
