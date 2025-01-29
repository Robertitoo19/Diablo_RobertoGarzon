using System;
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
    [NonSerialized] //para que el campo resetee entre partidas
    public int actualRepetition;
}
