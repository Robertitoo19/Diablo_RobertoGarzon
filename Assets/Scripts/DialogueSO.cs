using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
    [TextArea]
    public string[] prhases;
    public float timebetLetters; 
}