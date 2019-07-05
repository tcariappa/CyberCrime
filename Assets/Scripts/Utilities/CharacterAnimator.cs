using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    Animator anim;

    [SerializeField] int animationNumber = 0;
    [SerializeField] float timeDelay = 2;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(startAnimation());
    }

    IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(timeDelay);
        anim.SetInteger("Animation", animationNumber);
        
    }
}
