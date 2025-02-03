using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Riddle : MonoBehaviour
{
    [SerializeField] private GameObject riddlePanel;
    [SerializeField] private TMP_Text questionTxt;
    [SerializeField] private Button[] buttonsAnswers;

    private int correctAnswer;
    void Start()
    {
        riddlePanel.SetActive(false);
        SetQuestion();
    }

    private void SetQuestion()
    {
        questionTxt.text = "¿Que es una mazmorra?";
        buttonsAnswers[0].GetComponentInChildren<TMP_Text>().text = "Un laberinto";
        buttonsAnswers[1].GetComponentInChildren<TMP_Text>().text = "Un escondite";
        buttonsAnswers[2].GetComponentInChildren<TMP_Text>().text = "Una carcel"; 

        correctAnswer = 2;

        for (int i = 0; i < buttonsAnswers.Length; i++)
        {
            int index = i;
            buttonsAnswers[i].onClick.AddListener(() => CheckAnswer(index)); 
        }
    }

    private void CheckAnswer(int Choosen)
    {
        Debug.Log(Choosen);
        if (Choosen == correctAnswer)
        {
            Debug.Log("sfffff");
            riddlePanel.SetActive(false);
        }

    }
    public void ShowRiddle()
    {
        riddlePanel.SetActive(true);
    }
}
