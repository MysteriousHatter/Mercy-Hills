using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    //Day 1 tasks list
    public Item task0, task1b, task2;       //This references the Item class and creating objects of the class
    public locationTrigger task1a, task3, task6a1, task6a2, task6a3, task6a4, task6a5, task6a6, task6a7, task6a8;   //This references the locationTrigger class and creating objects of the class
    public ButtonInteractions task4, task5a, task5b, task6b1, task6b2, task6b3, task6b4, task7;    //This references the ButtonInteractions class and creating objects of the class

    public Item day2Tasks0, day2tasks9, day2tasks11, day2tasks14, day2tasks15;   //This references the Item class and creating objects of the class
    public locationTrigger day2Task3, day2tasks5, day2tasks8, day2tasks17; //This references the locationTrigger class and creating objects of the class
    public ButtonInteractions day2Tasks1, day2Task2, day2tasks4, day2tasks6, day2tasks7, day2tasks10, day2tasks12, day2tasks13, day2tasks16, day2tasks18, day2tasks19,
    day2tasks20, day2tasks21, day2tasks22, day2tasks23; //ences the ButtonInteractions class and creating objects of the class


    public float timer = 3f;

    IEnumerator generatorFunction;
  
    public bool screwDriver = false;
    public bool powerBox = false;
    public int wire = 0;

    public DayAnimations tasksFade;
    public TaskList taskList;
    public Status status;

    //This function keeps track of what task the player is currently on. Completed
    //Need to add a coroutine to switch the tasks
    //Need to add UI elements thats integrated with the coroutine
    //need to assign the button values to a dummy variable so that they don't go off again.

    private void Start()
    {
        generatorFunction = generatorTimer();

    }

    

    public void day1Tasks(int taskNum)
    {
        switch (taskNum)
        {
            case -2:
                Debug.Log("Shower activation before and after the task");
                //resetStatus function from the status script
                status.resetStatus();
                break;
            case -1:
                Debug.Log("Dummy Variable doing nothing");
                break;
            case 0:
                Debug.Log("Picked up task list"); // item tasks
                task1a.check = true;
                tasksFade.playAnimation();
                taskList.setString("Find the Lab 2");
                break;
            case 1:
                Debug.Log("Task 1a complete");
                task1b.check = true;
                tasksFade.playAnimation();
                taskList.setString("Retrieve Virus Syringe");
                break;
            case 2:
                Debug.Log("Task 1b complete");
                task2.check = true;
                tasksFade.playAnimation();
                taskList.setString("Retrieve Beaker of low pH from Lab 2");
                break;
            case 3:
                Debug.Log("Task 2 complete");
                task3.check = true;
                tasksFade.playAnimation();
                taskList.setString("Find the Lab 3");
                break;
            case 4:
                Debug.Log("Task 3 completed"); 
                task4.check = true;
                tasksFade.playAnimation();
                taskList.setString("Release the Virus into the Virus Chamber");
                break;
            case 5:
                Debug.Log("Task 4 complete"); //button task
                task5a.check = true;
                task4.turnOff();
                task5a.turnOn();
                tasksFade.playAnimation();
                taskList.setString("Put the Low pH into the Chamber");
                task4.taskNum = -1;
                break;
            case 6:
                Debug.Log("Task 5a complete");
                task5b.check = true;
                task5a.turnOff();
                task5b.turnOn();
                tasksFade.playAnimation();
                taskList.setString("Activate the Chamber");
                task5a.taskNum = -1;
                break;
            case 7:
                Debug.Log("Task 5b completed");
                task6a1.check = true;
                task6a2.check = true;
                task6a3.check = true;
                task6a4.check = true;
                task6a5.check = true;
                task6a6.check = true;
                task6a7.check = true;
                task6a8.check = true;

                task5b.turnOff();
                tasksFade.playAnimation();
                taskList.setString("Find the Decontamination Room");
                task5b.taskNum = -1;                //if the object is a button and needs to be reused later, hard code the change of the task number and the check boolean.
                break;
            case 8:
                Debug.Log("Task 6a complete");
                task6b1.check = true;
                task6b2.check = true;
                task6b3.check = true;
                task6b4.check = true;

                task6b1.taskNum = 9;
                task6b2.taskNum = 9;
                task6b3.taskNum = 9;
                task6b4.taskNum = 9;

                task6a1.turnOff();
                task6a2.turnOff();
                task6a3.turnOff();
                task6a4.turnOff();
                task6a5.turnOff();
                task6a6.turnOff();
                task6a7.turnOff();
                task6a8.turnOff();

                tasksFade.playAnimation();
                taskList.setString("Wash the Virus off using the shower");
                break;
            case 9:
                Debug.Log("Task 6b complete");
                task7.check = true;
                tasksFade.playAnimation();
                taskList.setString("Go to sleep. It's late");

                task6b1.taskNum = -2;
                task6b2.taskNum = -2;
                task6b3.taskNum = -2;
                task6b4.taskNum = -2;

                break;
            case 10:
                Debug.Log("Task 7 complete");  //cutscene to sleep and switch scenes or end it
                task7.check = true;
                task7.taskNum = -1;
                break;

        }
    }

    public void day2Tasks(int taskNum)
    {
        switch (taskNum)
        {
            case -1: //dummy variable with buttons
                Debug.Log("Dummy Variable doing nothing");
                break;
           
            case 0:
                Debug.Log("Picked up task day 2 list "); // item tasks

                day2Tasks1.check = true; 

                //StartCoroutine(generatorFunction);

                break;

            case 1:
                Debug.Log("activate 2nd phase of virus chamber");
                day2Task2.check = true; 
                //day2Tasks1.taskNum = -1; //since its a button we have to do this dummy var
                //so sadly the consol doesn't pick this case up
                //activate the second phase of the virus chamber
                //this'll be a button object
                break;
            case 2:
                Debug.Log("you made it to the room!");
                day2Task3.check = true;
                //area object because you need to head to the electric room
                //button object to turn on the generator 
                //this provokes the alarm to go off
                break;
               

            case 3:
                Debug.Log("turn on generator!");
                day2tasks4.check = true;
                //day2Task3.taskNum = -1;
                
                break;
            case 4:
                Debug.Log("Find the security room!");
                day2tasks5.check = true;
                //day2tasks4.taskNum = -1;
                //area object
                break;
            case 5:
                Debug.Log("Push the red button!");
                day2tasks6.check = true;
                //oddly enough it says task 5 was triggered...
                //day2tasks5.taskNum = -1;
                break;
            case 6:
                Debug.Log("Restart the chamber mechanism");
                day2tasks7.check = true;
                //day2tasks6.taskNum = -1;
                break;
            case 7:
                Debug.Log("Go to the chemical lab!!!!");
                day2tasks8.check = true;
                //button obj to place rna strand into the virus chamber
                //maybe later figure out a way for the character to carry an object and place it
                //this is the hard if else statements. if player doens't fix power and used generator need to continue to step 8
                //else skip to task 10
                break;
            case 8:
                Debug.Log("Grab the RNA strand jar");
                day2tasks9.check = true;
                //item object to find the card key quickly thats in the room
                break;
            case 9:
                Debug.Log("Put strand in virus chamber");
                day2tasks10.check = true;
                
                break;

            case 10:
                Debug.Log("Find the card key!");
                day2tasks11.check = true;
                break;

            case 11:
                Debug.Log("Fix the power!"); //button obj
                //however will probably need to do an if else statement
                
                day2tasks12.check = true;
                break;
            case 12:
                Debug.Log("Put RNA strand into the virus chamber to activate the mechanism!");
                day2tasks13.check = true;
                break;

            case 13:
                Debug.Log("Find the syringe!");
                day2tasks14.check = true;
                break;

            case 14:
                Debug.Log("Return to the testing lab and get a syringe full of the vaccine"); //item
                day2tasks15.check = true;
                break;

            case 15:
                Debug.Log("Test the vaccine on the rat"); //button
                day2tasks16.check = true;
                break;

            case 16:
                Debug.Log("Lab Leak! Head to the Security Room "); //area
                day2tasks17.check = true;
                break;

            case 17:
                Debug.Log("Press the Red Button");
                day2tasks18.check = true;
                break;

            case 18:
                Debug.Log("Check on the rat");
                day2tasks19.check = true;
                break;

            case 19:
                Debug.Log("Press the green button on the virus chamber device to mass produce the vaccine");
                day2tasks20.check = true;
                break;
            case 20:
                Debug.Log("Go to the decontamination room and clean the virus off of you");
                day2tasks21.check = true;
                //button
                break;

            case 21:
                Debug.Log("Drop off the completed vaccine in the drop off box in the decontamination room");
                day2tasks22.check = true;
                //button
                break;

            case 22:
                Debug.Log("you feel extremely tired go to sleep");
                day2tasks23.check = true;
                //button
                break;






            case 99: //generator reset
                Debug.Log("Dummy Variable doing nothing");
                break;

        }
    }



    IEnumerator generatorTimer()
    {
        turnOnPower();

        timer = 15f; //timer for the generator before the power turns off
        
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        Debug.Log("Timer complete");
        Debug.Log("Turning off lights");

        if(!screwDriver || wire < 3 || !powerBox)
        {
            turnOffPower();
        }

        //function or hard code the generator to be activated again.        
    }


    public void turnOnPower()
    {
        //turn on lights
        //turn off area virus
        //despawn additional enemies\
        //We'll have to use properties within the game manager script to spawn the enemies
        //if true- call MonsterSpawner
        GameManager.Instance.lightsOff = false;


    }

    public void turnOffPower()
    {
        //turn of lights
        //turn on area virus
        //spawn additional enemies
        //We'll have to use properties within the game manager script to spawn the enemies
        //if false- Deactive MonsterSpawner
        GameManager.Instance.lightsOff = true;
    }




}



//StopCoroutine(generatorFunction);
//timer = 15f;

//StartCoroutine(generatorFunction);


