using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.Playables;

public class SampleDialogue : MonoBehaviour
{
    public float PathPoint; //where the dialogue will activate
    public PlayableAsset Timeline;
    public Dialogue checker = new Dialogue();
    //public CinemachineSmoothPath cameracool;
    public CinemachineBrain brain;
   //public CinemachineSmoothPath dollyTrack;
    private CinemachineVirtualCamera vcam2;  //This is the main camera itself.
    CinemachineTrackedDolly cameraTrack; //This is the trackedDolly component attached to the current camera.
    private float pathPosition; //This is a variable to store path position or maybe keep it somewhere ready to use or compare.
    float me;
    bool started;
    public PlayableDirector Director;
    private PlayableAsset currentTimeline;
   






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vcam2 = brain.ActiveVirtualCamera as CinemachineVirtualCamera;
        cameraTrack = vcam2.GetCinemachineComponent<CinemachineTrackedDolly>();
        pathPosition = (float)Director.time;
        currentTimeline = Director.playableAsset;



        if (pathPosition >= PathPoint && !started && currentTimeline == Timeline)
        {
          StartCoroutine(Please(5));
          started = true;
        }
    }

    IEnumerator Please(float time)
    {        
        checker.StartDialogue("Please");
        me = checker.ineedtime();
        yield return new WaitForSeconds(me);
        checker.StartDialogue("Dont");
        me = checker.ineedtime();
        yield return new WaitForSeconds(me);
        checker.StartDialogue("Work");

    }



}


