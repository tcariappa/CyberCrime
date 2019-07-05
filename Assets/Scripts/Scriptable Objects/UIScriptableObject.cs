using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UI Person Data", menuName = "Pop Up UI Object", order = 51)]
public class UIScriptableObject : ScriptableObject
{
    public Sprite post1;
    public string title1, caption1;
    public string[] comment1 = new string[3];

    public Sprite post2;
    public string title2, caption2;
    public string[] comment2 = new string[3];

    public Sprite post3;
    public string title3, caption3;
    public string[] comment3 = new string[3];

    public float commentsTime;

}

