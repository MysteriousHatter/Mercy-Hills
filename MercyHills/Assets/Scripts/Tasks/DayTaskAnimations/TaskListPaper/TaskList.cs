using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    Animator animText;

    public Text tasksText;

    public bool check = true;

    public float timer = 2f;



    // Start is called before the first frame update
    void Start()
    {

        animText = GetComponent<Animator>();
    }

    private void Update()
    {
        if (check)
        {
            if (Input.GetButtonDown("RightBumper"))
            {
                check = false;
                animText.SetBool("check", true);
            }       
        }

        if (!check)
        {
            //timer -= Time.deltaTime;
            if (Input.GetButtonDown("LeftBumper"))
            {
                check = true;
                animText.SetBool("check", false);
            }
                

        }
    }

    public void setString(string text)
    {
        tasksText.text = text;     
    }
}
