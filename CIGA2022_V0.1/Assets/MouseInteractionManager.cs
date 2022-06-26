using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseTarget {puzzle};

public class MouseInteractionManager : MonoBehaviour
{
    public MouseTarget mouseTarget;
    public GameObject targetObject;

    public float angle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
/*            switch (mouseTarget)
            {
                case MouseTarget.puzzle:
                    
                    break;
                default:
                    break;
            }*/
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ClickRightButton!!!");
        }

        /*        if (Input.GetAxis("Mouse ScrollWheel")!=0)
                {
                    if (targetObject != null && targetObject.TryGetComponent(out Puzzle puzzle))
                    {
                        targetObject.transform.RotateAround(targetObject.transform.position,Vector3.forward * Input.GetAxis("Mouse ScrollWheel"),Time.deltaTime * rotateSpeed);
                    }
                }*/

        if (Input.GetMouseButtonDown(1))
        {
            if (targetObject != null && targetObject.TryGetComponent(out Puzzle puzzle))
            {
                //targetObject.transform.Rotate(Vector3.forward * angle);
                targetObject.GetComponent<Puzzle>().aM.rotateAudio.Play();
                targetObject.transform.RotateAround(transform.position, Vector3.forward, 90);
            }
        }

    }

    public void DragByTheMouse(GameObject target,Vector3 gap)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        Vector3 offset = Input.mousePosition - screenPos;
        //Debug.Log("Test" + (offset + Input.mousePosition));
        target.transform.position = Camera.main.ScreenToWorldPoint(screenPos + offset + gap);
        target.transform.position += Vector3.forward * 10;
    }
}
