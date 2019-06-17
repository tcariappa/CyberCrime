using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarNotes : MonoBehaviour
{
    [SerializeField] float notesDestroyTime;
    [SerializeField] float m_Speed;

    Rigidbody m_Rigidbody;
    Vector2 direction;
    void Start()
    {
        StartCoroutine(coNotesDestroyer());
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 10.0f;
        direction = Random.insideUnitCircle;
    }
    void Update()
    {
        m_Rigidbody.AddRelativeForce(direction * Time.deltaTime * m_Speed, ForceMode.Force);
    }
    IEnumerator coNotesDestroyer()
    {
        yield return new WaitForSeconds(notesDestroyTime);
        GuitarInteractionManager.doOnTapBad(gameObject);      
    }
}
