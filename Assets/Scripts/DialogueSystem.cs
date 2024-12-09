using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem System;
    //se ejecuta idependientemente de que el gameobject este activo o no.
    void Awake()
    {
        if (System == null)
        {
            System = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartDialogue(DialogueSO dialogue)
    {

    }
}
