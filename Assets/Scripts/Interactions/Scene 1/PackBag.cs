using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class PackBag : MonoBehaviour
{
    GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    Vector3 iniPosition;
    bool returningToPosition;
    int booksPacked;
    TimelineTransitions timeline;

    private void Start()
    {
        timeline = FindObjectOfType<TimelineTransitions>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!returningToPosition)
            {
                RaycastHit hitInfo;
                getTarget = null;
                getTarget = ReturnClickedObject(out hitInfo);
                if (getTarget != null)
                {
                    iniPosition = getTarget.transform.position;
                    isMouseDragging = true;
                    positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                    offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            if(getTarget != null)
            {
                isMouseDragging = false;
                returningToPosition = true;

                RaycastHit hitBag;                
                GameObject getBag = ReturnReleaseObject(out hitBag);
                if(getBag != null)
                {
                    packBag(getTarget);
                }
            }


        }

        if (isMouseDragging)
        {
            //tracking mouse position.
            //Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z - 0.55f);

            //converting screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
        }

        if(returningToPosition)
        {
            returnToPosition(iniPosition, getTarget);
        }
    }

    #region Get Targets
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
            hit.collider.enabled = false;
        }
        if (target != null && target.gameObject.CompareTag("book"))
            return target;
        else return null;
    }

    GameObject ReturnReleaseObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        if (target != null && target.gameObject.CompareTag("bag"))
        {
            return target;
        }
        else
        {
            return null;
        }

    }

    void returnToPosition(Vector3 bookPosition, GameObject target)
    {
        target.GetComponent<MeshCollider>().enabled = true;
        target.transform.position = Vector3.MoveTowards(target.transform.position, bookPosition, 3 * Time.deltaTime);

        if(target.transform.position == bookPosition)
        {
            returningToPosition = false;
        }
    }

    void packBag(GameObject book)
    {
        //Insert code for packing book 
        Destroy(book);
        returningToPosition = false;
        booksPacked++;

        if(booksPacked == 3)
        {
            timeline.changeTimelineNext();
        }
    }
    #endregion


}