using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class DeathTrigger1 : MonoBehaviour {

    //This script is attached to scene1: Darkzones --> DeathTrigger1
    float seconds;
    float startTime;
   
    static GameObject ceiling1;
    static TriggerScript lightOutAccess;
    static Animation animateScriptPlayer;
    public Light fLight;

    AudioSource audio1;
    public AudioClip deathStage1;
    public AudioClip deathStage2;

    //Prevent the sounds from playing more than once
    bool Stage1 = false;
    bool Stage2 = false;
    bool done = false;


    //Dark zone booleans 
    bool Scale1, Scale2, Scale3, Scale4 = false; 


    // Use this for initialization
    void Start()
    {
        //Creates an instance of the gameobject where the script we want to access is attached to
        GameObject ceilingLight1 = GameObject.Find("Ceiling light1");
        //Gets the script component so that unity can find it
        lightOutAccess = ceilingLight1.GetComponent<TriggerScript>();

        //creates an instance of our player gameobject, so that we can play death animation and also prevent the player from moving while it plays.
        //GameObject deathPlayer = GameObject.Find("FPSController");
        //animateScriptPlayer = deathPlayer.GetComponent<Animation>();

        //allows us to access the flashlight script to turn off the flashlight when the player goes in the dark zone
        GameObject flashLight = GameObject.Find("spotLight");
        fLight = flashLight.GetComponent<Light>();

        //allow us to import sounds into the script (Gets the component of the game object)
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(seconds + " D1");

        // // Shows what happens when running the counter
        //Debug.Log(seconds + " Seconds 1");
        //Debug.Log(startTime + " StartTime 1");
        //Debug.Log(Time.time + " Time since startup 1");


        //if (Input.GetKeyDown(KeyCode.E) ) {
        //   animateScriptPlayer.Play();
        //   }


        //Transforms the size and position of the triggerzone, happens everytime a light shuts off
        if (lightOutAccess.ceiling2_Off && Scale1 == false)
        {
            transform.localScale += new Vector3(0.2f, 0, 1.39f);
            transform.localPosition += new Vector3(0, 0, -0.67f);
            Scale1 = true;
        }

        if (lightOutAccess.ceiling3_Off && Scale2 == false)
        {
            transform.localScale += new Vector3(0, 0, 0.99f);
            transform.localPosition += new Vector3(0, 0, -0.53f);
            Scale2 = true;
        }


        if (lightOutAccess.ceiling4_Off && Scale3 == false)
        {
            transform.localScale += new Vector3(0, 0, 1.45f);
            transform.localPosition += new Vector3(0, 0, -0.63f);
            Scale3 = true;
        }

        //This last iteration is basically what happens when the last light go out. The whole map gets covered, basically forces sudden death on the player
        if (lightOutAccess.ceiling5_Off && Scale4 == false)
        {
            transform.localScale += new Vector3(9.55f, 0, 2.76f);
            Scale4 = true;
        }
    }

    //takes the curret Time.time, when we enter the triggerzone.. So that it may be substracted from time since startup, giving us a counter. 
    void OnTriggerEnter()
    {
        //Makes a timeStamp that you can use to subtract the Time.time command with. Giving you the difference, which is the amount of seconds past since you entered the
        //Triggerzone
        startTime = Time.time;
    }


    //unity funtion that check whether or not the gameobject this script is attached to has its collider triggered
    void OnTriggerStay()
    {
        //Checks whether or not you are inside the collider and for how long
        if (lightOutAccess.ceiling1_Off)
        {
            if (!done) { 
            startTime = Time.time;
            }
            fLight.enabled = false;
            counterTime();
            done = true;
        }  

        if (seconds >= 0.5 && lightOutAccess.ceiling1_Off && Stage1 == false)
        {
            audio1.PlayOneShot(deathStage1);
            Stage1 = true;
        } 

        if (seconds >= 2.5 && lightOutAccess.ceiling1_Off && Stage2 == false)
        {
            audio1.PlayOneShot(deathStage2);
            Stage2 = true;     
        } 

        if (seconds >= 6 && lightOutAccess.ceiling1_Off)
        { 
            //Debug.Log("Breathing1");
            lightOutAccess.gameStateOver();
        }
    }

    //unity funtion that check whether or not the gameobject this script is no longer being triggered
    void OnTriggerExit()
    {
        // resets the seconds, so that we can start again if we exit trigger zone
        seconds = 0;
        Stage1 = false;
        Stage2 = false;

    }

    //Calculates the difference and shows how long this funtion has been active for in seconds
    void counterTime()
    {
        seconds = Time.time - startTime;
    }
}
