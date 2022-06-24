using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public MouseInteractionManager miM;
    public bool isGrabbed;
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
            isGrabbed = true;
        }

        miM.DragByTheMouse(this.gameObject,-gap);
    }

    private void OnMouseUp()
    {
        isGrabbed = false;
    }
}
