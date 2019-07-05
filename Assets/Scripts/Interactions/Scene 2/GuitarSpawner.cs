using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarSpawner : MonoBehaviour
{
    [SerializeField] GameObject note;
    [SerializeField] float firstNote = 0.3f;
    [SerializeField] ScriptableObjectGuitar[] level;

    int curr_Level;
    int notesRemaining;

    void Start()
    {
        notesRemaining = level[0].numberOfNotes;
        InvokeRepeating("SpawnObject", firstNote, level[0].noteFrequency);
    }

    void startSpawning()
    {
        notesRemaining = level[curr_Level].numberOfNotes;
        InvokeRepeating("SpawnObject", 1.0f, level[curr_Level].noteFrequency);
    }

    public void SpawnObject()
    {
        Instantiate(note, transform.position, transform.rotation, gameObject.transform);
        notesRemaining--;
        if(notesRemaining == 0)
        {
            CancelInvoke("SpawnObject");
            curr_Level++;
            if (curr_Level < level.Length)
                startSpawning();
            else if (curr_Level >= level.Length)
            {
                //end interaction here
            }
        }

    }
}
