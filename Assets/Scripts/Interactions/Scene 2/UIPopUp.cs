using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class UIPopUp : MonoBehaviour
{
    public Image photo;
    public Text caption, nameOfPost, postComment;

    string[] comment;

    Animator UIController;
    int currentSet = 1;
    int commentNumber = 0;
    bool spawned = false;
    [SerializeField]
    UIScriptableObject person;
    [SerializeField] bool autoPop;
    [SerializeField] float timeToSpawn;

    PlayableDirector director;
    float time;

    private void Start()
    {
        director = Camera.main.GetComponent<PlayableDirector>();
        UIController = GetComponent<Animator>();
        changeImage();
        if (autoPop)
        {
            UIController.SetBool("autoPop", true);
        }
        StartCoroutine(coChangeComment());
    }
    private void Update()
    {
        time = Mathf.Round((float)director.time);
        

        Vector3 targetPos = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(targetPos);

        if(autoPop && !spawned && time >= timeToSpawn)
        {
            openUI();
        }
    }
    public void openUI()
    {
        UIController.SetTrigger("openUI");
    }
    public void startChangeImage()
    {
        UIController.SetTrigger("changeImage");
    }
    public void changeImage()
    {
        if (currentSet == 3)
            currentSet = 1;
        else currentSet++;

        if(currentSet == 1)
        {
            photo.overrideSprite = person.post1;
            nameOfPost.text = person.title1;
            caption.text = person.caption1;
            comment = person.comment1;
        }
        else if(currentSet == 2)
        {
            photo.overrideSprite = person.post2;
            nameOfPost.text = person.title2;
            caption.text = person.caption2;
            comment = person.comment2;
        }
        else if (currentSet == 3)
        {
            photo.overrideSprite = person.post3;
            nameOfPost.text = person.title3;
            caption.text = person.caption3;
            comment = person.comment3;
        }
    }
    void changeComment()
    {
        postComment.text = comment[commentNumber];

        if (commentNumber == 2)
            commentNumber = 0;
        else commentNumber++;

        StartCoroutine(coChangeComment());
    }
    IEnumerator coChangeComment()
    {
        yield return new WaitForSeconds(2.5f);
        changeComment();
    }
}
