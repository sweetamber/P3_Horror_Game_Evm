using UnityEngine;
using System.Collections;

public class Tutorial_Events : MonoBehaviour {
    //This script is attached to "Scene 1: tutorial Section -> Tutorial Events" && "Scene 1: tutorial Section -> panel_Switches -> cellDoorLight"

    Light tutorial_Light;
        
    bool blinkOn = false;
    bool ready = true;
    public bool narrationOver = false;

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
        //Debug.Log("TriggerEvent");

        //ready indicates that the player has entered the trigger zone for the first time, and is made false, so that it wont play tutorial narration again
        if (ready && narrationOver == false) {
            //Debug.Log(ready);
            audio1.Play();
            ready = false;
        }
        // event timing, counts to the amount of seconds that the narration takes, and then activates the blinking red button, and enables the player to press it though another script (tutorialDoor)
        StartCoroutine("EventTiming");
    }
}
