using UnityEngine;
using System.Collections;

public class EndSceneTrigger : MonoBehaviour {

    //This script is attached to "Scene 3: EndScene_trigger

        //variables for customized counter
    float seconds;
    float Startime;

    //Acces the lights above the doors
    Light blackDoor_Light;
    Light yellowDoor_Light;

    //BlinkOn is to turn light on and off
    //Ready is used to make sure that the OnTriggerEnter is only activated once.
    bool blinkOn = false;
    bool ready = true;

    //So that you may know when the narration is finished, this is used in other scripts
    public bool narrationOver = false;

    //1: defines the time between blinks
    public float timeBlink;
    public float timeTriggerEvents;

    //Variable for the audioSource component
    AudioSource audio1;
 

    // Use this for initialization
    void Start()
    {
        //Accesses the blackDoor GameObject And component light, so that we may turn it on and off
        //Same goes for the code below it, just for accessing the yellowDoor
        GameObject blackDoor_Ending = GameObject.Find("Spotlight_BlackDoor");
        blackDoor_Light = blackDoor_Ending.GetComponent<Light>();

        GameObject yellowDoor_Ending = GameObject.Find("Spotlight_YellowDoor");
        yellowDoor_Light = yellowDoor_Ending.GetComponent<Light>();

        //To attach the component audioSource to our variable
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //To time other events with the narration, in this case, to match up the light to turn on and off according to what is said in the narration (Choosing a door)
        seconds = Time.time - Startime;
        //Debug.Log(seconds + " Scene3");

        if (seconds > 28 && narrationOver == false)
        yellowDoor_Light.enabled = true;

        if(seconds > 35 && narrationOver == false)
            yellowDoor_Light.enabled = false;

        if (seconds > 36 && narrationOver == false)
            blackDoor_Light.enabled = true;

        if (seconds > 42 && narrationOver == false)
            blackDoor_Light.enabled = false;


        //made this if statement to ensure that the coroutine is only run once every second.. So that the light will appear to blink
        if (blinkOn == true)
        {
            StartCoroutine("Blink");
            blinkOn = false;
        }
    }


    IEnumerator Blink()
    {
        yield return new WaitForSeconds(timeBlink);
        //Makes the light blink the opposite of what it state is, which means, if it is off, it will turn on and vice versa
        blackDoor_Light.enabled = !blackDoor_Light.enabled;
        yellowDoor_Light.enabled = !yellowDoor_Light.enabled;
        blinkOn = true;
    }

    //Times the narration, so that we can activate, in this case, BlinkOn and tell the game that the narration is Over
    IEnumerator EventTiming()
    {
        yield return new WaitForSeconds(timeTriggerEvents);

        blinkOn = true;
        narrationOver = true;

    }

    //Starts the narration and the events that happens during the narration (The light turns on and off at specified times, see update function)
    void OnTriggerEnter()
    {
        //ready indicates that the player has entered the trigger zone for the first time, and is made false, so that it wont play tutorial narration again
        if (ready && narrationOver == false)
        {
            // event timing, counts to the amount of seconds that the narration takes, and then activates the blinking red button, and enables the player to press it though another script (tutorialDoor)
            Startime = Time.time;
            audio1.Play();
            ready = false;
        }
       
        //I wonder what this does :) 
        StartCoroutine("EventTiming");
    }
}
