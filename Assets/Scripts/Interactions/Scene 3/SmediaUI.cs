using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmediaUI : MonoBehaviour
{
    Vector3 initialPosition;
    float lerpTime = 1f;
    float currentLerpTime;

    float moveDistance = 1.5f;
    Vector3 startPos;
    Vector3 endPos;
    [SerializeField] SwitchScriptableObject switchScriptable;
    [SerializeField] Image[] allImages = new Image[3];
    int postSet = 0;
    int postNo = 0;
    void Start()
    {
        initialPosition = transform.localPosition;
        currentLerpTime = lerpTime;
        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
        for(int i = 0; i < allImages.Length; i++)
        {
            allImages[i].sprite = switchScriptable.postSet1[i];
        }
    }

    void Update()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
            float yPos;
            yPos = Mathf.Round(transform.localPosition.y * 10f) / 10f;
            transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z); 
            startPos = transform.position;
            endPos = transform.position + transform.up * moveDistance;
        }

        if (currentLerpTime != 1)
        {
            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
        }
    }

    public void changePost()
    {
        if (postNo < 2)
        {
            postNo++;
            currentLerpTime = 0f;   
        }
        else
        {
            GetComponentInParent<SwitchUI>().switchScreen();
            Reset();
        }
    }

    private void Reset()
    {
        float delay = GetComponentInParent<SwitchUI>().switchDelayTime;
        StartCoroutine(resetDelay(delay));
    }

    IEnumerator resetDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime + lerpTime);
        transform.localPosition = initialPosition;
        postNo = 0;
        postSet++;
        for (int i = 0; i < allImages.Length; i++)
        {
            allImages[i].overrideSprite = switchScriptable.postSetDetector(postSet, i);
        }
    }
}