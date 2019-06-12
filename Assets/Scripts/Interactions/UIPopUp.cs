using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUp : MonoBehaviour
{
    public Image photo;
    public Text caption, nameOfPost, postComment;

    string[] comment;

    Animator UIController;
    int currentSet = 1;
    int commentNumber = 0;
    float commentsDelay = 1.0f;

    [SerializeField]
    UIScriptableObject person;

    private void Start()
    {
        UIController = GetComponent<Animator>();
        changeImage();
        StartCoroutine(coChangeComment());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            UIController.SetTrigger("changeImage");
        }

    }
    public void openUI()
    {
        UIController.SetTrigger("openUI");
    }
    public void changeImage()
    {
        if (currentSet == 3)
            currentSet = 1;
        else currentSet++;

        if(currentSet == 1)
        {
            photo.overrideSprite = person.post1;
            //photo.sprite = person.post1;
            nameOfPost.text = person.title1;
            caption.text = person.caption1;
            comment = person.comment1;
        }
        else if(currentSet == 2)
        {
            photo.overrideSprite = person.post2;
            //photo.sprite = person.post2;
            nameOfPost.text = person.title2;
            caption.text = person.caption2;
            comment = person.comment2;
        }
        else if (currentSet == 3)
        {
            photo.overrideSprite = person.post3;
            //photo.sprite = person.post3;
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
        yield return new WaitForSeconds(commentsDelay);
        changeComment();
    }
}
