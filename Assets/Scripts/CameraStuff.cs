using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TapOnDoorExit : MonoBehaviour
{
    private CinemachineVirtualCamera vcam1; //This is the main camera itself.
    CinemachineTrackedDolly cameraTrack; //This is the trackedDolly component attached to the current camera.
    float pathPosition; //This is a veruiable to store path position or maybe keep it somewhere ready to use or compare.

    void Start()
    {
        cameraTrack = vcam1.GetCinemachineComponent<CinemachineTrackedDolly>();
        //This is to get the tracked dolly component attached to the current rendering cinemachine camera.
        pathPosition = cameraTrack.m_PathPosition;
        //cameraTrack.m_pathposition gets you the current path position of the camera.
    }
}