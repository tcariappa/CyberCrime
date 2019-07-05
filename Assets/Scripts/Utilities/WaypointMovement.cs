using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public  Transform[] waypoints;
    public GameObject toMove;
    public int waypointIndex;
    [Range(0, 5)]
    public float speed, turnspeed;
    float turnDistance;
    Animator sarahAnim;
    private void Start()
    {
        sarahAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (waypointIndex < waypoints.Length)
        {
            if (toMove.transform.position != waypoints[waypointIndex].position)
            {
                Vector3 lookPos = waypoints[waypointIndex].transform.position - toMove.transform.position;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                toMove.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnspeed);

                toMove.transform.position = Vector3.MoveTowards(toMove.transform.position, waypoints[waypointIndex].position, Time.deltaTime * speed); /*Vector3.Distance(toMove.transform.position, waypoints[waypointIndex].position)*/
            }
            else waypointIndex++;
        }
        else if(waypointIndex >= waypoints.Length)
        {
            sarahAnim.SetTrigger("StopWalking");
        }
    }
}
