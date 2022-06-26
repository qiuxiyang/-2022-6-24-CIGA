using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public MouseInteractionManager miM;
    public Puzzle targetPuzzle;
    public bool isGrabbed;
    public bool isSettled;
    public bool isInBoardLine;
    public bool isOnBoard;
    public bool isOnEdge;
    public List<GameObject> colliders;

    private void Awake()
    {
        miM = FindObjectOfType<MouseInteractionManager>();
    }

    private void Update()
    {
        if(miM.targetObject != null)
        {
            targetPuzzle = miM.targetObject.GetComponent<Puzzle>();
        }



        if(targetPuzzle != null)
        {
            isGrabbed = targetPuzzle.isGrabbed;
            isSettled = targetPuzzle.isSettled;
            isInBoardLine = targetPuzzle.isInBoardLine;
            isOnBoard = targetPuzzle.isOnBoard;
            isOnEdge = targetPuzzle.isOnEdge;
            colliders = targetPuzzle.collidingPuzzles;
        }
    }


}
