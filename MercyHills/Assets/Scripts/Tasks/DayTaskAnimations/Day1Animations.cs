using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1Animations : MonoBehaviour
{

    Animator animText;


    IEnumerator ResetAnimation;
       

    public Text dayTasksText;

    public bool check = true;

    public float timer = 2f;



    // Start is called before the first frame update
    void Start()
    {
        ResetAnimation = reset();
        animText = GetComponent<Animator>();
    }

    private void Update()
    {
        if (check)
        {
            timer -= Time.deltaTime;

            if(timer < 0f)
            {
                check = false;
                animText.SetBool("check", false);
            }
        }
        
        
     
        
    }

    public void playAnimation(string text)
    {
        dayTasksText.text = text;
        timer = 2f;
        animText.SetBool("check", true);
        check = true;

        //StartCoroutine(ResetAnimation);

    }


    IEnumerator reset()
    {
        //turnOnPower();
        timer = 2f;
        //timer to reset animation status

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;

        }

        Debug.Log("Test");
        animText.SetBool("check", false);
        timer = 2f;
        yield break;

    }



}

//animText.SetBool("check", false);