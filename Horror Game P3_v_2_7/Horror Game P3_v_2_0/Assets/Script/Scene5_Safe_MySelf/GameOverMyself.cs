using UnityEngine;
using System.Collections;

public class GameOverMyself : MonoBehaviour {

    //This script is attached to Scene5_save_myself: EndEventsTriggerMyself

        //variables to make customized trigger
    float seconds;
    float startTime;

    //Makes variables for audioSource and allow us to use multiple audioClip from the same source
    AudioSource audio1;
    public AudioClip deathStage1;
    public AudioClip deathStage2;
    public AudioClip endNarrationSaveMyself;
    public AudioClip lightOff;

    //Game object we wish to access (variable) 
    GameObject ceilingLight1;

    //Prevent the sounds from playing more than once during different trigger events
    bool Stage0 = false;
    bool Stage1 = false;
    bool Stage2 = false;
    bool Stage3 = false;
    bool Stage4 = false;


    // Use this for initialization
    void Start()
    {
        //Creates an instance of the gameobject where the script we want to access is attached to
        ceilingLight1 = GameObject.Find("Ceiling light1");

        //allow us to import sounds into the script (Gets the component of the game object)
        audio1 = GetComponent<AudioSource>();

        //Resets the timer so that "Seconds starts at zero rather than however long the game has been running, problem with arise you if you just set it to 
        //seconds = Time.time, as the game continues from the previous scene 
        startTime = Time.time;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //Debug.Log(seconds + " Dmyself");
        
    //      // Shows what happens when running the counter
    //     Debug.Log(seconds + " Seconds myself");
    //     Debug.Log(startTime + " StartTime myself");
    //     Debug.Log(Time.time + " Time since startup myself");


    //}

    //unity funtion that check whether or not the gameobject this script is attached to has its collider triggered
    void OnTriggerStay()
    {
        //This onTriggerStay is a series of events on the endScene where player chooses to safe himself
        //after 1 second the narration starts, after 4.6 seconds the light turns off, after 7 seconds a deathTrigger is activated, not unlike the one throughout the game.
        //Counts the time the player is on the trigger in seconds
        seconds = Time.time - startTime;
        if (seconds >= 1 && Stage0 == false)
        {
            audio1.volume = 0.5f;
            audio1.PlayOneShot(endNarrationSaveMyself);
            //Debug.Log("Breathing0");
            Stage0 = true;
        }

        if(seconds >= 4.6f && Stage1 == false)
        {
            //Destroys the ceiling light(turns light off)
            audio1.PlayOneShot(lightOff);
            Destroy(ceilingLight1);
            Stage1 = true;
        }

        if (seconds >= 7 && Stage2 == false)
        {
            audio1.volume = 1;
            //Plays the breathing sound
            audio1.PlayOneShot(deathStage1);
            Stage2 = true;
        }

        if (seconds >= 10 && Stage3 == false)
        {
            //Turns the volume to max before death_Scream
            audio1.volume = 1;
            //Plays the death_Scream
            audio1.PlayOneShot(deathStage2);
            Stage3 = true;
        }
        //Ends the game
        if(seconds >= 13 && Stage4 == false)
        {
            //Debug.Log("Die");
        }
    }
}
