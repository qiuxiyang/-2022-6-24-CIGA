using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public int currentLevelIndex;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public GameObject nextLevelButton;

    public GameObject currentLevel;
    public PuzzleManager currentPM;
    public void OnClickNextLevel()
    {
        if(currentLevelIndex == 1)
        {
            level1.SetActive(false);
            level2.SetActive(true);
            currentLevel = level2;
            currentPM = level2.GetComponentInChildren<PuzzleManager>();
        }
        else
        {
            level2.SetActive(false);
            level3.SetActive(true);
            currentLevel = level3;
            currentPM = level3.GetComponentInChildren<PuzzleManager>();

        }

        nextLevelButton.SetActive(false);
    }
}
