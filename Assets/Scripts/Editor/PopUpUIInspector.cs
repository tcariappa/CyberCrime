using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIScriptableObject))]
public class PopUpUIInspector : Editor
{
    bool set1, set2, set3 = false;
    bool comments1,comments2,comments3 = false;

    public override void OnInspectorGUI()
    {
        UIScriptableObject UI_Script = (UIScriptableObject)target;

        set1 = EditorGUILayout.Foldout(set1, "First set of Media");
            if (set1)
            {
                UI_Script.post1 = (Sprite)EditorGUILayout.ObjectField("First Image", UI_Script.post1, typeof(Sprite), true);
                UI_Script.title1 = EditorGUILayout.TextField("Name of Person", UI_Script.title1);
                UI_Script.caption1 = EditorGUILayout.TextField("Post Caption", UI_Script.caption1);
                EditorGUI.indentLevel++;
                    comments1 = EditorGUILayout.Foldout(comments1, "Comments under post");
                    if (comments1)
                    {
                        UI_Script.comment1[0] = EditorGUILayout.TextField("Comment 1", UI_Script.comment1[0]);
                        UI_Script.comment1[1] = EditorGUILayout.TextField("Comment 2", UI_Script.comment1[1]);
                        UI_Script.comment1[2] = EditorGUILayout.TextField("Comment 3", UI_Script.comment1[2]);
                    }
                EditorGUI.indentLevel--;
            }
            else comments1 = false;

        EditorGUILayout.Space();

        set2 = EditorGUILayout.Foldout(set2, "Second set of Media");
            if (set2)
            {
                UI_Script.post2 = (Sprite)EditorGUILayout.ObjectField("Second Image", UI_Script.post2, typeof(Sprite), true);
                UI_Script.title2 = EditorGUILayout.TextField("Name of Person", UI_Script.title2);
                UI_Script.caption2 = EditorGUILayout.TextField("Post Caption", UI_Script.caption2);
                EditorGUI.indentLevel++;
                comments2 = EditorGUILayout.Foldout(comments2, "Comments under post");
                    if (comments2)
                    {
                        UI_Script.comment2[0] = EditorGUILayout.TextField("Comment 1", UI_Script.comment2[0]);
                        UI_Script.comment2[1] = EditorGUILayout.TextField("Comment 2", UI_Script.comment2[1]);
                        UI_Script.comment2[2] = EditorGUILayout.TextField("Comment 3", UI_Script.comment2[2]);
                    }
                EditorGUI.indentLevel--;
            }
            else comments2 = false;

        EditorGUILayout.Space();

        set3 = EditorGUILayout.Foldout(set3, "Third set of Media");
            if (set3)
            {
                UI_Script.post3 = (Sprite)EditorGUILayout.ObjectField("Second Image", UI_Script.post3, typeof(Sprite), true);
                UI_Script.title3 = EditorGUILayout.TextField("Name of Person", UI_Script.title3);
                UI_Script.caption3 = EditorGUILayout.TextField("Post Caption", UI_Script.caption3);
                EditorGUI.indentLevel++;
                comments3 = EditorGUILayout.Foldout(comments3, "Comments under post");
                    if (comments3)
                    {
                        UI_Script.comment3[0] = EditorGUILayout.TextField("Comment 1", UI_Script.comment3[0]);
                        UI_Script.comment3[1] = EditorGUILayout.TextField("Comment 2", UI_Script.comment3[1]);
                        UI_Script.comment3[2] = EditorGUILayout.TextField("Comment 3", UI_Script.comment3[2]);
                    }
                EditorGUI.indentLevel--;
            }
            else comments3 = false;

        EditorGUILayout.Space();

        EditorGUILayout.FloatField("Comments Delay in seconds", UI_Script.commentsTime);
    }
}
