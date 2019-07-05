using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarInteractionManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Notes"))
                {
                    doOnTap(hit.collider.gameObject);
                }
            }
        }
    }

    public static void doOnTap(GameObject note)
    {
        print("good note");
        Destroy(note);
    }
    public static void doOnTapBad(GameObject note)
    {
        print("bad note");
        Destroy(note);
    }
}



