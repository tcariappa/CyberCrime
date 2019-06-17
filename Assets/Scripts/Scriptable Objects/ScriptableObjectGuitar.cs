using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guitar Level Data", menuName = "Level of Guitar", order = 51)]
public class ScriptableObjectGuitar : ScriptableObject
{
    [SerializeField] public float noteFrequency;
    [SerializeField] public int numberOfNotes;
    //[SerializeField] public float levelDuration;

}
