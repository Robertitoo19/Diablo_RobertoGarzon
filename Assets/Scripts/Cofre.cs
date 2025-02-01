using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteractable
{
    private Outline outline;

    [SerializeField] private Texture2D defaultIcon;
    [SerializeField] private Texture2D interactIcon;
    void Start()
    {
        outline = GetComponent<Outline>();
    }
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(interactIcon, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultIcon, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }

    public void interact(Transform interactor)
    {
    }
}
