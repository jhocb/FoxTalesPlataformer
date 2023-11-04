using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    public PuzzleManager puzzleManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CUBO") && Input.GetKeyDown(KeyCode.E) && puzzleManager.currentIndex == 2 && puzzleManager.complete == false)
        {
            puzzleManager.StartCoroutine(puzzleManager.KeyE());
        }
        else if (other.CompareTag("CUBO") && Input.GetKeyDown(KeyCode.E) && puzzleManager.currentIndex != 2 && puzzleManager.complete == false)
        {
            puzzleManager.DeactivateAllObjects();
        }
    }
}
