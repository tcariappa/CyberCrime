using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextingUI : MonoBehaviour
{
    GameObject[] textBoxes;
    Vector3[] initialPos;
    int textNo = 0;
    readonly float lerpTime = 1f;
    float currentLerpTime;
    public TextMeshProUGUI[] allTextBoxes = new TextMeshProUGUI[6];
    public TextMeshProUGUI[] allTextBoxes1 = new TextMeshProUGUI[6];

    readonly float moveDistance = 1.1f;
    Vector3 startPos;
    Vector3 endPos;
    bool firstText = true, npcText;
    int messageSet = 0;
    [SerializeField] SwitchScriptableObject switchScriptable;
    TextMeshProUGUI textMeshPro;

    private void Start()
    {

        textBoxes = new GameObject[transform.childCount - 2];
        initialPos = new Vector3[transform.childCount - 2];
        for (int i = 0; i < transform.childCount - 2; i++)
        {
            textBoxes[i] = transform.GetChild(i).gameObject;
            initialPos[i] = transform.GetChild(i).transform.position;
            allTextBoxes[i].SetText(switchScriptable.messageSet1[i]);
        }
        currentLerpTime = lerpTime;

        textMeshPro = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        //allTextBoxes1[0] = textBoxes[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {          
            currentLerpTime = lerpTime;
        }

        if (currentLerpTime != 1)
        {
            float perc = currentLerpTime / lerpTime;
            textBoxes[textNo].transform.position = Vector3.Lerp(startPos, endPos, perc); //Lerping
        }
        else if (textNo % 2 != 0 && !npcText)
        {
            PressButton(true);
            npcText = true;
        }
    }
    public void PressButton(bool result)
    {
        if (result && !firstText && textNo < transform.childCount - 3)
        {
            textNo++;
            startPos = textBoxes[textNo].transform.position;
            endPos = textBoxes[textNo].transform.position + transform.up * moveDistance;
            currentLerpTime = 0f;
        }
        else if(result && firstText)
        {
            startPos = textBoxes[textNo].transform.position;
            endPos = textBoxes[textNo].transform.position + transform.up * moveDistance;
            firstText = false;
            currentLerpTime = 0f;
        }
        else if(textNo >= transform.childCount - 3)
        {
            GetComponentInParent<SwitchUI>().switchScreen();
            Reset();
        }

        if (npcText)
            npcText = false;
    }
    public void Reset()
    {
        float delay = GetComponentInParent<SwitchUI>().switchDelayTime;
        StartCoroutine(resetDelay(delay));

    }
    IEnumerator resetDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime + lerpTime);
        messageSet++;
        for (int i = 0; i < transform.childCount - 2; i++)
        {
            //textBoxes[i].transform.SetPositionAndRotation(new Vector3(transform.position.x, initialPos[i].y, transform.position.z), Quaternion.Euler(new Vector3(0f,109.7f,0f)));
            textBoxes[i].transform.position = (new Vector3(textBoxes[i].transform.position.x, initialPos[i].y, textBoxes[i].transform.position.z));
            allTextBoxes[i].SetText(switchScriptable.messageSetDetector(messageSet,i));
        }
        textNo = 0;
        firstText = true;
        npcText = false;
    }
}
