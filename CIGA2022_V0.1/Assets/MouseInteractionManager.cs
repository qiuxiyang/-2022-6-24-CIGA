using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseTarget {puzzle};

public class MouseInteractionManager : MonoBehaviour
{
    public MouseTarget mouseTarget;
    public GameObject targetObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (mouseTarget)
            {
                case MouseTarget.puzzle:
                    
                    break;
                default:
                    break;
            }
        }
    }

    public void DragByTheMouse(GameObject target,Vector3 gap)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        Vector3 offset = Input.mousePosition - screenPos;
        Debug.Log("Test" + (offset + Input.mousePosition));
        target.transform.position = Camera.main.ScreenToWorldPoint(screenPos + offset + gap);
        target.transform.position += Vector3.forward * 10;
    }
}
