using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public int currentLevel;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public void OnClickNextLevel()
    {
        if(currentLevel == 1)
        {
            level1.SetActive(false);
            level2.SetActive(true);
        }
        else
        {
            level2.SetActive(false);
            level3.SetActive(true);
        }
    }
}
