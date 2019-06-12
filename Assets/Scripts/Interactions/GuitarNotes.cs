using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarNotes : MonoBehaviour
{
    [SerializeField] float notesDestroyTime;

    void Start()
    {
        StartCoroutine(coNotesDestroyer());
    }

    IEnumerator coNotesDestroyer()
    {
        yield return new WaitForSeconds(notesDestroyTime);
        GuitarInteractionManager.doOnTapBad(gameObject);      
    }
}
