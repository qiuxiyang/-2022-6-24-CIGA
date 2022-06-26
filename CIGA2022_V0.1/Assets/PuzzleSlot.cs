using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public Puzzle puzzlePrefab;
    public bool isGrab;
    public Puzzle grabbingPuzzle;
    public List<GameObject> sprites;
    public int currentAmount;
    public bool isRunOut;
    public LevelMaster lvM;

    private void Awake()
    {
        lvM = FindObjectOfType<LevelMaster>();
    }

    private void OnMouseDown()
    {
        if (!isRunOut)
        {
            Puzzle newPuzzle = Instantiate(puzzlePrefab);
            isGrab = true;
            newPuzzle.transform.SetParent(lvM.currentLevel.transform);
            newPuzzle.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
            grabbingPuzzle = newPuzzle;
            newPuzzle.pM.UpdateAmount(newPuzzle.type,-1);
            newPuzzle.aM.chooseAudio.Play();
        }

    }
    private void OnMouseDrag()
    {
        if (isGrab)
        {
            grabbingPuzzle.ByMouseDrug();
        }
    }

    private void OnMouseUp()
    {
        if(grabbingPuzzle != null)
        {
            grabbingPuzzle.ByMouseUp();
            grabbingPuzzle = null;
            isGrab = false;
        }

    }

    public void AdjustSlotSprites(int adjustAmount)
    {
        if (currentAmount > adjustAmount)
        {
            DecreaseSprite();
        }
        else if(currentAmount < adjustAmount)
        {
            IncreaseSprite();
        }
    }

    public void DecreaseSprite()
    {
        if(currentAmount == 1)
        {
            ChangeColorAlpha(0.3f);
            isRunOut = true;
        }
        else
        {
            sprites[currentAmount - 2].SetActive(false);
        }
        currentAmount -= 1;
    }

    public void IncreaseSprite()
    {
        if(currentAmount == 0)
        {
            ChangeColorAlpha(1);
            isRunOut = false;
        }
        else
        {
            sprites[currentAmount - 1].SetActive(true);
        }
        currentAmount += 1;
    }

    public void ChangeColorAlpha(float alpha)
    {
        Color originalColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}
