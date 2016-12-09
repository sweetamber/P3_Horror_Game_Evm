using UnityEngine;
using System.Collections;

public class JumpScare_Scene2_Yellow_CellDoor : MonoBehaviour {

    //This Script is attached to Scene2: JumpScare --> prison_door_action_A2 yellow

        //This script contains a repeat structure, which means that even if the intended procedure is followed by the player, the 
        //Jumpscare will not bug out on the player, it will keep resetting itself everytime the player don't stick around to trigger it

    float seconds;
    float startTime;

    
    static TriggerScript_scene2 lightOutAccess;

    //Adds 2 animation variables
    Animation MonsterWindow;
    Animation ZombieWindow;

    AudioSource audio1;
    public AudioClip deathStage1;
    public AudioClip deathStage2;
    public AudioClip deathStage3;
    public AudioClip Locked;

    //Prevent the sounds from playing more than once
    bool Stage1 = false;
    bool Stage2 = false;
    bool playOnceOpen = false;
    bool done = false;


    // Use this for initialization
    void Start()
    {
        //Creates an instance of the gameobject where the script we want to access is attached to
        GameObject JumpScare_Cell = GameObject.Find("prison_door_action_A2 (1)");
        //To play animation on zombie
        GameObject JumpScare_Cell_Zombie = GameObject.Find("z@walk");

        MonsterWindow = JumpScare_Cell.GetComponent<Animation>();
        ZombieWindow = JumpScare_Cell_Zombie.GetComponent<Animation>();       

        //allow us to import sounds into the script (Gets the component of the game object)
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(seconds + " D1");

        // Shows what happens when running the counter
        //Debug.Log(seconds + " Seconds Jumpscare");
        //Debug.Log(startTime + " StartTime Jumpscare");
        //Debug.Log(Time.time + " Time since startup Jumpscare");

    }

    //takes the curret Time.time, when we enter the triggerzone.. So that it may be substracted from time since startup, giving us a counter. 
    void OnTriggerEnter()
    {
        startTime = Time.time;
    }


    //unity funtion that check whether or not the gameobject this script is attached to has its collider triggered
    void OnTriggerStay()
    {

        if (Input.GetKeyDown(KeyCode.E) && playOnceOpen == false)
        {
            //This plays a sound signifying the door is locked
            audio1.PlayOneShot(Locked);
            Debug.Log("Door locked!");
            //Makes sure that you can only do it once
            playOnceOpen = true;
        }

        //If the player has tried the door, then it will make a new timeStamp (So the events won't happen instantly)
        if(playOnceOpen == true)
        {
            //This makes a new timeStamp
            if (!done)
            {
                startTime = Time.time;
            }
            //This starts the counter and stops the timeStamp from being updated all the time, thus allowing 
            //"seconds" to count up and trigger events.
            counterTime();
            done = true;
        }

        //Triggers growling and banging on metal event. Stage1 makes sure it can only be done once
        if (seconds >= 1 && Stage1 == false)
        {
            audio1.PlayOneShot(deathStage1);
            audio1.PlayOneShot(deathStage2);
            Stage1 = true;
        }
      
        //This triggers animation and makes sure it can only happen once
        if (seconds >= 3 && Stage2 == false)
        {
            //Debug.Log("Play AnimationS");
            MonsterWindow.Play();
            audio1.PlayOneShot(deathStage3);
            ZombieWindow.Play();
            Stage2 = true;
        }
    }

    //unity funtion that check whether or not the gameobject this script is no longer being triggered
    void OnTriggerExit()
    {
        seconds = 0;
        // gives the player a second chance to try and trigger the jumpscare, if he walked away the first time
        if (Stage1 == false)
        {
            playOnceOpen = false; done = false;
        }
    }

    //Calculates the difference and shows how long this funtion has been active for in seconds
    void counterTime()
    {      
            seconds = Time.time - startTime;
    }
}
