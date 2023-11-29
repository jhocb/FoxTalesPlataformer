using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{

    public PuzzleManager puzzleManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CUBO") && Input.GetKeyUp(KeyCode.E) && puzzleManager.currentIndex == 0 && puzzleManager.complete == false)
        {
            puzzleManager.StartCoroutine(puzzleManager.KeyE());
        }
        else if (other.CompareTag("CUBO") && Input.GetKeyUp(KeyCode.E) && puzzleManager.currentIndex != 0 && puzzleManager.complete == false)
        {
            puzzleManager.DeactivateAllObjects();
        }
    }

}
