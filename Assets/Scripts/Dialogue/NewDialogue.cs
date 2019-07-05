using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.Playables;

public class NewDialogue : MonoBehaviour
{
    public float Seconds; //where the dialogue will activate
    public PlayableAsset Timeline;
    public Dialogue checker = new Dialogue();    
    public string[] Dialogues;         
    private float pathPosition; //This is a variable to store path position or maybe keep it somewhere ready to use or compare.
    float me;
    bool started;
    public PlayableDirector Director;
    private PlayableAsset currentTimeline;
    
    // Update is called once per frame
    void Update()
    {        
        pathPosition = (float)Director.time;
        currentTimeline = Director.playableAsset;

        if (pathPosition >= Seconds && !started && currentTimeline == Timeline)
        {
            StartCoroutine(Please());
            started = true;
        }
    }

    IEnumerator Please()
    {
        for (int i = 0; i < Dialogues.Length; i++)
        {
            checker.StartDialogue(Dialogues[i]);
            print(Dialogues[i]);
            me = checker.ineedtime();
            yield return new WaitForSeconds(me);
        }        
    }



}

