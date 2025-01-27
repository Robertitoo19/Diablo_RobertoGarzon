using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem System;
    //se ejecuta idependientemente de que el gameobject este activo o no.
    [SerializeField] private TMP_Text dialogueTxt;
    [SerializeField] private GameObject dialogueFrame;

    [SerializeField] private Transform npcCamera;

    private bool writing;
    private int actualPhraseIndex = 0;

    private DialogueSO actualDialogue;

    [SerializeField] private EventManagerSO eventManager;
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
    public void StartDialogue(DialogueSO dialogue, Transform cameraPoint)
    {
        Time.timeScale = 0;
        //El dialogo actual que tenemos que tratar es el que me pasan por parámetro.
        actualDialogue = dialogue;
        dialogueFrame.SetActive(true);
        //posicionar y rotar camara al punto.
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        StartCoroutine(WritePhrase());
    }
    private IEnumerator WritePhrase()
    {
        writing = true;

        //Limpiar texto.
        dialogueTxt.text = string.Empty;

        //Descomponer la frase actual por caracteres.
        char[] phraseInLetters = actualDialogue.phrases[actualPhraseIndex].ToCharArray();

        foreach (char letter in phraseInLetters)
        {
            //1.Incluir la letra en el texto
            dialogueTxt.text += letter;
            //2. Esperar

            //WaitForSecondsRealTime: No se para si el tiempo está congelado.
            yield return new WaitForSecondsRealtime(actualDialogue.timebetLetters);

        }
        writing = false;
    }
    private void CompletePhrase()
    {
        //Si me piden completar la frase entera, en el texto pongo la frase entera
        dialogueTxt.text = actualDialogue.phrases[actualPhraseIndex];
        //Y paro las Corrutinas que puedan estar vivas.
        StopAllCoroutines();

        writing = false;
    }
    public void SiguienteFrase()
    {
        //Si no estoy escribiendo....
        if (!writing)
        {
            //avanzo a la siguiente frase.
            actualPhraseIndex++;

            //Si aun me quedan frases por sacar...
            if (actualPhraseIndex < actualDialogue.phrases.Length)
            {
                //La escribo
                StartCoroutine(WritePhrase());
            }
            else
            {
                EndDialogue();
            }
        }
        else
        {
            CompletePhrase();
        }

    }
    private void EndDialogue()
    {
        Time.timeScale = 1;
        //Cerrar marco de dialogo.
        dialogueFrame.SetActive(false);

        //Posteriores dialogos empezemos desde indice 0.
        actualPhraseIndex = 0;

        if (actualDialogue.hasMission)
        {
            eventManager.NewMission(actualDialogue.mission);
        }

        //Ya no hay dialogo que escribir.
        actualDialogue = null; 
    }
}
