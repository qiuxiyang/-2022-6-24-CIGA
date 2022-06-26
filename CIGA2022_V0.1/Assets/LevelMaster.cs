using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public int currentLevelIndex;
    public bool isTitleUp;
    public bool isPrepare;

    public bool isReady;
    public GameObject title;
    public TextManager tM;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public AudioMaster aM;

    public float upSpeed;
    public int targetHeight;

    public GameObject nextLevelButton;
    public GameObject startButton;

    public GameObject currentLevel;
    public PuzzleManager currentPM;

    private void Awake()
    {
        aM = FindObjectOfType<AudioMaster>();
    }
    public void OnClickNextLevel()
    {
        aM.startAudio.Play();

        if(currentLevelIndex == 1)
        {
            level1.SetActive(false);
            level2.SetActive(true);
            currentLevelIndex += 1;
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

    public void OnClickStart()
    {
        aM.startAudio.Play();
        isTitleUp = true;
    }

    void Update()
    {
        if (isTitleUp)
        {
            startButton.SetActive(false);
            title.transform.position += Vector3.up * Time.deltaTime * upSpeed;
        }

        if(title.transform.position.y >= targetHeight && !isPrepare)
        {
            isPrepare = true;
            isTitleUp = false;
            title.SetActive(false);
            tM.talkPanel.SetActive(true);
            tM.StartCoroutine(tM.StartPlayText());
        }
    }
}
