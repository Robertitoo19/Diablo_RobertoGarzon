using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    [SerializeField] private TorchPuzzle torchPuzzle;
    public void interact(Transform interactor)
    {
        torchPuzzle.TurnOnTorch(gameObject);
    }
}
