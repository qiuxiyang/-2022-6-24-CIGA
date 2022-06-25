using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public MouseInteractionManager miM;
    public bool isGrabbed;
    public bool isSettled;
    public bool isOnBoard;
    public bool isOnEdge;
    public Vector3 gap;

    private void Awake()
    {
        miM = FindObjectOfType<MouseInteractionManager>();
    }
    private void OnMouseDrag()
    {
        if (!isGrabbed)
        {
            gap = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position) + Vector3.forward * 10;
            this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 11;
            miM.targetObject = this.gameObject;

            isGrabbed = true;
        }

        miM.DragByTheMouse(this.gameObject,-gap);
    }

    private void OnMouseUp()
    {
        if (isOnBoard && !isOnEdge)
        {
            isSettled = true;
        }

        isGrabbed = false;
        this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 10;
        miM.targetObject = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Puzzle")
        {
            if (isGrabbed)
            {
                this.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Board")
        {
            isOnBoard = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Puzzle")
        {
            if (isGrabbed)
            {
                this.GetComponentInChildren<SpriteRenderer>().color = Color.black;
            }
        }
        if (collision.collider.tag == "Board")
        {
            isOnBoard = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Board")
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            isOnEdge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Board")
        {
            isOnEdge = false;

            if (isOnBoard)
            {
                this.GetComponentInChildren<SpriteRenderer>().color = Color.black;
            }
        }
    }
}
