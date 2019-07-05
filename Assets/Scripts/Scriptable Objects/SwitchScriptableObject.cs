using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Switching UI", menuName = "Switch UI object", order = 52)]
public class SwitchScriptableObject : ScriptableObject
{
    public Sprite[] postSet1 = new Sprite[3];
    public string[] messageSet1 = new string[6];

    [Space]
    public Sprite[] postSet2 = new Sprite[3];
    public string[] messageSet2 = new string[6];

    [Space]
    public Sprite[] postSet3 = new Sprite[3];
    public string[] messageSet3 = new string[6];

    [Space]
    public string[] messageSet4 = new string[6]; 

    public string messageSetDetector(int setNo, int messageNo)
    {
        string[] messageset = new string[6];
        if (setNo == 1)
            messageset = messageSet2;
        else if (setNo == 2)
            messageset = messageSet3;
        else if (setNo == 3)
            messageset = messageSet4;

        return messageset[messageNo];
    }
    public Sprite postSetDetector(int setNo, int postNo)
    {
        Sprite[] postset = new Sprite[6];
        if (setNo == 1)
            postset = postSet2;
        else if (setNo == 2)
            postset = postSet3;

        return postset[postNo];
    }
}
