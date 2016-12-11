using UnityEngine;
using System.Collections;

public class Tutorial_Events : MonoBehaviour
{
    //This script is attached to "Scene 1: tutorial Section -> Tutorial Events" && "Scene 1: tutorial Section -> panel_Switches -> cellDoorLight"

    Light tutorial_Light;

    bool blinkOn = false;
    bool ready = true;
    public bool narrationOver = false;

    //This to cancel narration a second time, if narration played once, then narrationPlayedOnce = 1, if = 1, then skip narratioon
    public int narrationPlayedOnce;

    public float timeBlink = 0.5f;
    public float timeTriggerEvents = 10f;

    AudioSource audio1;
    public AudioClip narration;

    // Use this for initialization
    void Start()
    {
        GameObject spotLight = GameObject.Find("cellDoorLight");
        tutorial_Light = spotLight.GetComponent<Light>();
        audio1 = GetComponent<AudioSource>();

        //Takes the value from the PlayerPrefs and sets it to narration played once, if the narration has been played, then it will be set to one and therefor not played again
        //If PlayerPrefs holds no record of the variable NarrationDoneOnce, then it is set to zero
        narrationPlayedOnce = PlayerPrefs.GetInt("narrationDoneOnce", 0);
    }

    // Update is called once per frame
    void Update()
    {
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
        tutorial_Light.enabled = !tutorial_Light.enabled;
        blinkOn = true;
    }

    IEnumerator EventTiming()
    {
        yield return new WaitForSeconds(timeTriggerEvents);

        blinkOn = true;
        narrationOver = true;
    }

    void OnTriggerEnter()
    {
        //ready indicates that the player has entered the trigger zone for the first time, and is made false, so that it wont play tutorial narration again
        //If the narrationPlayOnce is zero it means that the narration has yet to be played, it is then set to 1, and this will be remember for as long as the
        //application is running
        if (ready == true && narrationOver == false && narrationPlayedOnce == 0)
        {
            audio1.Play();
            narrationPlayedOnce = 1;
            PlayerPrefs.SetInt("narrationDoneOnce", narrationPlayedOnce);
            ready = false;
        }
        //when the script is run a second time during runTime, the value narrationPlayedOnce is = 1 and ready is again equal to true, thus this will be run instead of narration 
        else if (ready == true && narrationPlayedOnce == 1)
        {
            timeTriggerEvents = 0;
            ready = false;
        }
        // event timing, counts to the amount of seconds that the narration takes, and then activates the blinking red button, and enables the player to press it though another script (tutorialDoor)
        StartCoroutine("EventTiming");
    }

    void OnApplicationQuit()
    {
         narrationPlayedOnce = 0;
         PlayerPrefs.SetInt("narrationDoneOnce", narrationPlayedOnce);
    }

}
