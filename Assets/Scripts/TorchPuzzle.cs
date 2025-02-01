using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPuzzle : MonoBehaviour
{
    [SerializeField] private List<GameObject> torchs;
    private List<GameObject> playerSecuence = new List<GameObject>();

    public static event Action OnCorrectSecuence;

    public void TurnOnTorch(GameObject torch)
    {
        if (playerSecuence.Count < torchs.Count)
        {
            playerSecuence.Add(torch);
            torch.GetComponentInChildren<Light>().enabled = true;

            if(playerSecuence.Count == torchs.Count)
            {
                CheckSecuence();
            }
        }
    }

    private void CheckSecuence()
    {
        for (int i = 0; i < torchs.Count; i++)
        {
            if (playerSecuence[i] != torchs[i])
            {
                ResetPuzzle();
                return;
            }
        }
        OnCorrectSecuence?.Invoke();
    }

    private void ResetPuzzle()
    {
        playerSecuence.Clear();
        foreach (GameObject p in torchs)
        {
            p.GetComponentInChildren<Light>().enabled = false;
        }
    }
}
