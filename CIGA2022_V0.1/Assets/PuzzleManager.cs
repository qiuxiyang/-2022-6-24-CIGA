using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int pokerAmount;
    public int gemAmount;
    public int rabbitAmount;
    public int pigeonAmount;
    public int roseAmount;

    public PuzzleSlot pokers;
    public PuzzleSlot gems;
    public PuzzleSlot rabbits;
    public PuzzleSlot pigeons;
    public PuzzleSlot roses;

    public void UpdatePoker()
    {
        Debug.Log("Test1111" + pokerAmount);
        pokers.AdjustSlotSprites(pokerAmount);
    }
}
