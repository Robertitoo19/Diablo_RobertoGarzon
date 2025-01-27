using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mission")]
public class MissionSO : ScriptableObject
{
    public string inicialmessage;
    public string finalmessage;
    public bool hasrepetition;
    public int totalRepetitions;
    public int missionIndex;

    public int actualRepetition;
}
