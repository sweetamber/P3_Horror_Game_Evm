using UnityEngine;
using System.Collections;

public class DeathTrigger0 : MonoBehaviour {

    //This script is attached to scene1: Darkzones --> DeathTrigger0

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


    // Use this for initialization
    void Start()
    {
        //Creates an instance of the gameobject where the script we want to access is attached to
        GameObject ceilingLight1 = GameObject.Find("Ceiling light1");
        //Gets the script component so that unity can find it
        lightOutAccess = ceilingLight1.GetComponent<TriggerScript>();

        //allows us to access the flashlight script to turn off the flashlight when the player goes in the dark zone
        GameObject flashLight = GameObject.Find("spotLight");
        fLight = flashLight.GetComponent<Light>();

        //allow us to import sounds into the script (Gets the component of the game object)
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(seconds + " D0");
        /*
          // Shows what happens when running the counter
         Debug.Log(seconds + " Seconds 0");
         Debug.Log(startTime + " StartTime 0");
         Debug.Log(Time.time + " Time since startup 0");
*/
    
    }

    //takes the curret Time.time, when we enter the triggerzone.. So that it may be substracted from time since startup, giving us a counter. 
    void OnTriggerEnter()
    {
        startTime = Time.time;
    }


    //unity funtion that check whether or not the gameobject this script is attached to has its collider triggered
    void OnTriggerStay()
    {

        if (lightOutAccess.ceiling0_Off_Tutorial)
        {
            if (!done)
            {
                startTime = Time.time;
            }
            fLight.enabled = false;
            counterTime();
            done = true;
        }

        if (seconds >= 0.5 && lightOutAccess.ceiling0_Off_Tutorial && Stage1 == false)
        {
            audio1.PlayOneShot(deathStage1);
            Stage1 = true; 
        }

        if (seconds >= 2.5 && lightOutAccess.ceiling0_Off_Tutorial && Stage2 == false)
        {
            audio1.PlayOneShot(deathStage2);
            Stage2 = true;
        }

        if (seconds >= 6 && lightOutAccess.ceiling0_Off_Tutorial)
        {
            //Debug.Log("Breathing0");
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
