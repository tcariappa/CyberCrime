using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchUI : MonoBehaviour
{
    float lerpTime = 0.5f;
    float currentLerpTime;

    float moveDistance = 1.0f;
    Vector3 socialStartPos, messageStartPos;
    Vector3 socialEndPos, messageEndPos;
    bool firstMessage = true;

    GameObject[] bothUI;
    bool socialMedia = true;
    int SwitchNo = 0;
    public float switchDelayTime;

    void Start()
    {
        bothUI = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            bothUI[i] = transform.GetChild(i).gameObject;
        }

        firstSwitch();
    }

    void Update()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        if (currentLerpTime != 1)
        {
            float perc = currentLerpTime / lerpTime;
            bothUI[1].transform.position = Vector3.Lerp(socialStartPos, socialEndPos, perc);
            bothUI[0].transform.position = Vector3.Lerp(messageStartPos, messageEndPos, perc);
            if (!socialMedia && firstMessage && perc == 1)
            {
                print("Must Press button");
                GetComponentInChildren<TextingUI>().PressButton(true);
                firstMessage = false;
            }
        }
    }

    public void switchScreen()
    {
        StartCoroutine(switchDelay());       
    }

    IEnumerator switchDelay()
    {
        yield return new WaitForSeconds(switchDelayTime);
        if (socialMedia)
        {
            socialStartPos = bothUI[1].transform.position;
            socialEndPos = bothUI[1].transform.position + (-transform.right) * moveDistance;

            messageStartPos = bothUI[0].transform.position;
            messageEndPos = bothUI[0].transform.position + (transform.right) * moveDistance;

            socialMedia = false;
        }
        else
        {
            socialStartPos = bothUI[1].transform.position;
            socialEndPos = bothUI[1].transform.position + (transform.right) * moveDistance;

            messageStartPos = bothUI[0].transform.position;
            messageEndPos = bothUI[0].transform.position + (-transform.right) * moveDistance;

            socialMedia = true;
            firstMessage = true;
        }
        currentLerpTime = 0f;
        SwitchNo++;
    }

    void firstSwitch()
    {

        if (socialMedia)
        {
            socialStartPos = bothUI[1].transform.position;
            socialEndPos = bothUI[1].transform.position + (-transform.right) * moveDistance;

            messageStartPos = bothUI[0].transform.position;
            messageEndPos = bothUI[0].transform.position + (transform.right) * moveDistance;

            socialMedia = false;
        }
        else
        {
            socialStartPos = bothUI[1].transform.position;
            socialEndPos = bothUI[1].transform.position + (transform.right) * moveDistance;

            messageStartPos = bothUI[0].transform.position;
            messageEndPos = bothUI[0].transform.position + (-transform.right) * moveDistance;

            socialMedia = true;
        }
        currentLerpTime = 0f;
    }
}
