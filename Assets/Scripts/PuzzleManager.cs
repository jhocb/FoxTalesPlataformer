using UnityEngine;
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzleObjects; // Arraste os objetos do quebra-cabeça aqui
    public int currentIndex = 0;
    public bool complete = false;

    void Start()
    {
        DeactivateAllObjects();
    }

    private void Update()
    {
        //Debug.Log(currentIndex);
    }



    public void DeactivateAllObjects()
    {
        //print("Desativou");
        foreach (GameObject obj in puzzleObjects)
        {
            obj.SetActive(false);
        }
        currentIndex = 0;
    }

    public IEnumerator KeyE()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Apertou E");
        puzzleObjects[currentIndex].SetActive(true);
        currentIndex++;
        if (currentIndex == puzzleObjects.Length)
        {
            Debug.Log("Quebra-cabeça resolvido!");
            complete = true;
        }
    }

}
