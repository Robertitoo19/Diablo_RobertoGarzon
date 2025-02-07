using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour, IInteractable
{
    [SerializeField] private TorchPuzzle torchPuzzle;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;
    public void interact(Transform interactor)
    {
        torchPuzzle.TurnOnTorch(gameObject);
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
    }
}
