using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public List<string> introTextList;
    public int index;
    public Text textBox;
    public float speakSpeed;
    public GameObject confirmButton;
    public GameObject talkPanel;
    public AudioMaster aM;
    public LevelMaster lvM;

    private void Awake()
    {
        lvM = FindObjectOfType<LevelMaster>();
    }
    public IEnumerator StartPlayText()
    {
        textBox.text = "";

        for (int i = 0; i < introTextList[index].Length; i++)
        {
            textBox.text += introTextList[index][i];


            yield return new WaitForSeconds(speakSpeed);
        }

        confirmButton.SetActive(true);

    }

    public void OnClickConfirm()
    {
        aM.startAudio.Play();
        index += 1;
        if(index == introTextList.Count)
        {
            talkPanel.SetActive(false);
            lvM.isReady = true;
        }
        else
        {
            StartCoroutine(StartPlayText());
        }
        confirmButton.SetActive(false);
    }
}
