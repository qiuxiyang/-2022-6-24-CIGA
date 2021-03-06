using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleType {poker,gem,pigeon,rabbit,rose,cane,takecopt,elephant,snake,knife};

public class Puzzle : MonoBehaviour
{
    public MouseInteractionManager miM;
    public LevelMaster lvM;
    public PuzzleManager pM;
    public AudioMaster aM;
    public bool isGrabbed;
    public bool isSettled;
    public bool isInBoardLine;
    public bool isOnBoard;
    public bool isOnEdge;
    public List<GameObject> collidingPuzzles;
    public Vector3 gap;
    public PuzzleType type;

    public void ChangeColorAlpha(float alpha)
    {
        Color originalColor = GetComponentInChildren<SpriteRenderer>().color;
        GetComponentInChildren<SpriteRenderer>().color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }

    private  void Awake()
    {
        miM = FindObjectOfType<MouseInteractionManager>();
        pM = FindObjectOfType<PuzzleManager>();
        aM = FindObjectOfType<AudioMaster>();
        lvM = FindObjectOfType<LevelMaster>();
        collidingPuzzles = new List<GameObject>();
    }

    private void OnMouseDrag()
    {
        ByMouseDrug();
    }

    public void ByMouseDrug()
    {
        if (!isGrabbed)
        {
            gap = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position) + Vector3.forward * 10;
            this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 11;
            miM.targetObject = this.gameObject;

            isGrabbed = true;
        }

        miM.DragByTheMouse(this.gameObject, -gap);
    }

    public void ByMouseUp()
    {
        if (isOnBoard && !isOnEdge && collidingPuzzles.Count == 0)
        {
            aM.settleAudio.Play();
            isSettled = true;
            if (pM.isReady)
            {
                aM.nextLvAudio.Play();
                lvM.currentLevelIndex += 1;

                if (lvM.currentLevelIndex == 4)
                {
                    lvM.end.SetActive(true);
                    lvM.leaveButton.SetActive(false);
                    lvM.quitButton.SetActive(true);
                }
                else
                {
                    lvM.nextLevelButton.SetActive(true);
                }
            }
        }
        else
        {
            isSettled = false;
            aM.cancelAudio.Play();
            pM.UpdateAmount(type,1);
        }

        isGrabbed = false;
        this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 10;
        miM.targetObject = null;

        if (!isSettled)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseUp()
    {
        ByMouseUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Puzzle")
        {
            if (isGrabbed)
            {
                collidingPuzzles.Add(collision.gameObject);
                ChangeColorAlpha(0.3f);
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Puzzle")
        {
            if (isGrabbed)
            {
                collidingPuzzles.Remove(collision.gameObject);
                if(collidingPuzzles.Count == 0 && !isOnEdge)
                {
                    ChangeColorAlpha(1f);
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Board")
        {
            isInBoardLine = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BoardEdge")
        {
            ChangeColorAlpha(0.3f);
            isOnEdge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "BoardEdge")
        {
            isOnEdge = false;

            if (isInBoardLine)
            {
                isOnBoard = true;
            }
            else
            {
                isOnBoard = false;
            }

            if (isOnBoard && collidingPuzzles.Count == 0)
            {
                ChangeColorAlpha(1);
            }
        }

        if (collision.tag == "Board")
        {
            isInBoardLine = false;
        }
    }



}
