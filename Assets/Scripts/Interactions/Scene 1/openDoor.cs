using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    TimelineTransitions timeline;

    private void Start()
    {
        timeline = FindObjectOfType<TimelineTransitions>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            print("Mouse Pressed");
            RaycastHit hitDoor;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitDoor))
            {
                print(" Hit = " + hitDoor.collider.gameObject.name);
                if (hitDoor.collider.gameObject.CompareTag("Door"))
                {
                    timeline.changeTimelineNext();
                }
            }
        }
    }
}
