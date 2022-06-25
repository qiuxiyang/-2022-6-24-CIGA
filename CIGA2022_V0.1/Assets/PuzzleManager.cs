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
    public int takecoptAmount;

    public PuzzleSlot pokers;
    public PuzzleSlot gems;
    public PuzzleSlot rabbits;
    public PuzzleSlot pigeons;
    public PuzzleSlot roses;
    public PuzzleSlot canes;
    public PuzzleSlot knives;
    public PuzzleSlot elephants;
    public PuzzleSlot snakes;
    public PuzzleSlot takecopts;


    public void UpdateAmount(PuzzleType type,int change)
    {
        switch (type)
        {
            case PuzzleType.poker:
                pokerAmount += change;
                pokers.AdjustSlotSprites(pokerAmount);
                break;
            case PuzzleType.gem:
                gemAmount += change;
                gems.AdjustSlotSprites(gemAmount);
                break;
            case PuzzleType.rabbit:
                rabbitAmount += change;
                rabbits.AdjustSlotSprites(rabbitAmount);
                break;
            case PuzzleType.pigeon:
                pigeonAmount += change;
                pigeons.AdjustSlotSprites(pigeonAmount);
                break;
            case PuzzleType.rose:
                roseAmount += change;
                roses.AdjustSlotSprites(roseAmount);
                break;
            case PuzzleType.snake:
                snakeAmount += change;
                snakes.AdjustSlotSprites(snakeAmount);
                break;
            case PuzzleType.takecopt:
                takecoptAmount += change;
                takecopts.AdjustSlotSprites(takecoptAmount);
                break;
            case PuzzleType.elephant:
                elephantAmount += change;
                elephants.AdjustSlotSprites(elephantAmount);
                break;
            case PuzzleType.knife:
                knifeAmount += change;
                knives.AdjustSlotSprites(knifeAmount);
                break;
            case PuzzleType.cane:
                caneAmount += change;
                canes.AdjustSlotSprites(caneAmount);
                break;
        }
    }
}
