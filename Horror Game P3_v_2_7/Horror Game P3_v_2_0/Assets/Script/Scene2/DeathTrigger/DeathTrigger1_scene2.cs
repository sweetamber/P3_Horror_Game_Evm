using UnityEngine;
using System.Collections;

public class DeathTrigger1_scene2 : MonoBehaviour {

    //This script is attached to scene2: lamps--> prisonLamp_b_long1 (1) --> Ceiling light1

        //The following script is a true copy of the DeathTrigger from scene1, can be located in Project: -->scripts-->scene1--> Light_OFF_deathZones --> DeathTrigger1 or DeathTrigger0
        //The functionality is explained more in detail there

    float seconds;
    float startTime;

    static GameObject ceiling1;
    static TriggerScript_scene2 lightOutAccess;

    //static Animation animateScriptPlayer;
    public Light fLight;

    AudioSource audio1;
    public AudioClip deathStage1;
    public AudioClip deathStage2;

    //Prevent the sounds from playing more than once
    bool Stage1 = false;
    bool Stage2 = false;

    bool done = false;

    bool Scale1 = false;
    bool Scale2 = false;
    bool Scale3 = false;
    bool Scale4 = false;
    bool Scale5 = false;



    // Use this for initialization
    void Start()
    {
        //Creates an instance of the gameobject where the script we want to access is attached to
        GameObject ceilingLight1 = GameObject.Find("Ceiling light1");
        //Gets the script component so that unity can find it
        lightOutAccess = ceilingLight1.GetComponent<TriggerScript_scene2>();

        //creates an instance of our player gameobject, so that we can play death animation and also prevent the player from moving while it plays.
        //GameObject deathPlayer = GameObject.Find("FPSController");
        //animateScriptPlayer = deathPlayer.GetComponent<Animation>();

        //allows us to access the flashlight script to turn off the flashlight when the player goes in the dark zone
        GameObject flashLight = GameObject.Find("spotLight");
        fLight = flashLight.GetComponent<Light>();

        audio1 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(seconds + " D1");

        // Shows what happens when running the counter
        //Debug.Log(seconds + " Seconds 1");
        //Debug.Log(startTime + " StartTime 1");
        //Debug.Log(Time.time + " Time since startup 1");


        //if (Input.GetKeyDown(KeyCode.E) ) {
        //   animateScriptPlayer.Play();
        //   }

        //For each light turned off, the scale and position of the box collider Aka. Deathtrigger will increase to an appropriate size
        if (lightOutAccess.ceiling2_Off && Scale1 == false)
        {
            transform.localScale += new Vector3(0, 0, 13.5f);
            transform.localPosition += new Vector3(0, 0, -4.5f);
            Scale1 = true;
        }

        if (lightOutAccess.ceiling3_Off && Scale2 == false)
        {
            transform.localScale += new Vector3(0, 0, 11.39f);
            transform.localPosition += new Vector3(0, 0, -6.22f);
            Scale2 = true;
        }


        if (lightOutAccess.ceiling4_Off && Scale3 == false)
        {
            transform.localScale += new Vector3(0, 0, 13.31f);
            transform.localPosition += new Vector3(0, 0, -5.89f);
            Scale3 = true;
        }

        if (lightOutAccess.ceiling5_Off && Scale4 == false)
        {
            transform.localScale += new Vector3(0, 0, 13.31f);
            transform.localPosition += new Vector3(0, 0, -5.89f);
            Scale4 = true;
        }

        //This last iteration is basically what happens when the last light go out. The whole map gets covered, basically forces sudden death on the player
        if (lightOutAccess.ceiling6_Off && Scale5 == false)
        {
            transform.localScale += new Vector3(70f, 0, 50f);
            transform.localPosition += new Vector3(0, 0, -8f);
            Scale5 = true;
        }

    }

    //takes the curret Time.time, when we enter the triggerzone.. So that it may be substracted from time since startup, giving us a counter. 
    void OnTriggerEnter()
    {
        seconds = 0;
        startTime = Time.time;
    }


    //unity funtion that check whether or not the gameobject this script is attached to has its collider triggered
    void OnTriggerStay()
    {

        if (lightOutAccess.ceiling1_Off)
        {
            if (!done)
            {
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
            Debug.Log(Stage1);
        }

        if (seconds >= 2.5 && lightOutAccess.ceiling1_Off && Stage2 == false)
        {
            audio1.PlayOneShot(deathStage2);
            Stage2 = true;
            Debug.Log(Stage2);
        }

        if (seconds >= 6 && lightOutAccess.ceiling1_Off)
        {  
            /*Debug.Log("Breathing1");*/
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
        if (lightOutAccess.ceiling1_Off)
        {
        seconds = Time.time - startTime;
        }
        
    }
}
