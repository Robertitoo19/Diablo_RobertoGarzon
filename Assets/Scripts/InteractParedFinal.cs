using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractParedFinal : MonoBehaviour, IInteractable
{
    [SerializeField] private MissionSO mission;
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;
    [SerializeField] private TMP_Text messageTxt;
    public void interact(Transform interactor)
    {
        if(mission.actualRepetition >= mission.totalRepetitions)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnMouseEnter()
    {
        if (mission.actualRepetition < mission.totalRepetitions)
        {
            messageTxt.text = "Necesitas recoger las tres runas para continuar.";
        }
        else
        {
            messageTxt.text = "Click para interactuar.";
        }
        messageTxt.enabled = true;
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        messageTxt.enabled = false;
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
    }
}
