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
    public int caneAmount;
    public int knifeAmount;
    public int elephantAmount;
    public int snakeAmount;

    public PuzzleSlot pokers;
    public PuzzleSlot gems;
    public PuzzleSlot rabbits;
    public PuzzleSlot pigeons;
    public PuzzleSlot roses;
    public PuzzleSlot canes;
    public PuzzleSlot knives;
    public PuzzleSlot elephants;
    public PuzzleSlot snakes;


    public void UpdateAmount(PuzzleType type,int change)
    {
        switch (type)
        {
            case PuzzleType.poker:
                pokerAmount += change;
                pokers.AdjustSlotSprites(pokerAmount);
                break;
            case PuzzleType.cane:
                caneAmount += change;
                canes.AdjustSlotSprites(caneAmount);
                break;
        }
    }
}
