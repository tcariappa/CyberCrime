using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
//using UnityEngine.Cinemachine

public class Dialogue : MonoBehaviour
{
    public DialogueKeeper[] ListofDie;
    public Text DialogueBox; //Actual Text of the Box
    //public float PathNumber; //Where on Dolly Track should dialogue start 
    private float timing; //how long should it reamin on screen    
    bool dialogue = false; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    

    public void StartDialogue(string Dialoguenames) //use this function in script to be called. 
    {
         

            dialogue = true;


        if (dialogue == true)
        {            
            for (int i = 0; i < ListofDie.Length; i++) 
            {
                if (ListofDie[i].DialogueName == Dialoguenames)
                {
                    DialogueBox.text = ListofDie[i].Subtitle;
                    print(DialogueBox.text);
                    timing = ListofDie[i].WaitSec;                   
                }
            }
           StartCoroutine(Wait(timing));
        }
            
        
            
    }

    IEnumerator Wait(float time)
    {
        if (dialogue == true)
        {
            print("Im active");
            DialogueBox.enabled = true;
            yield return new WaitForSeconds(time);
            DialogueBox.enabled = false;
            dialogue = false;
            print("Im dead");
        }
       
    }

   public float ineedtime()
    {
        return timing; 
    }

}
