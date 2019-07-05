using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineTransitions : MonoBehaviour
{
    [SerializeField] TimelineAsset[] timelines;
    int timelineNumber = 0;

    public void changeTimelineNext()
    {
        PlayableDirector mainPlayable;
        timelineNumber++;

        mainPlayable = Camera.main.GetComponent<PlayableDirector>();
        mainPlayable.Play(timelines[timelineNumber]);

    }
}
