using UnityEngine;
using System.Collections;

public class EndSceneFlickering : MonoBehaviour {

    // this script is attached to "Scene 5_safe_Myself: ->prisonLamp_b_shortA2 -> Ceiling light1"

    public float speedOfFligger = 0.3f;
    int fliggering;
    bool playOnce;

    Light lights;

    AudioSource audio1;


    bool flag = true;


    void Start()
    {

        audio1 = GetComponent<AudioSource>();
        //GameObject ceiling_HallWay = GameObject.Find("Ceiling light_HallWay");
        lights = GetComponent<Light>();

    }


    void Update()
    {
        //Booleans make stops the loop (Update), so to many won't be active at a time
        if (playOnce == false)
        {
            //speedOfFligger = Random.Range(0.1f, 0.5f);
            StartCoroutine("Environment_fligger"); playOnce = true;
        }
    }




    void OnTriggerExit()
    {
        if (flag)
        {
            flag = false;
        }
    }

    IEnumerator Environment_fligger()
    {

        yield return new WaitForSeconds(speedOfFligger);
        //Makes the light change its range consistently, thus making the illusion of fliggering light, place these 2 lines in the update and you will see flickering as well
        //Couroutine, was just made to slow the flickering down, match it better with sound_effect
        lights.range = Random.Range(1, 8);
        //by placing playOnce before determining the light, we start a coroutine before it is decides if the light is on or off, this gives the light a more random flickering
        //rather than a flickering that appears to be timed.
        playOnce = false;

        //Basically just takes a random value between 0,1, if its lower than 0.5f, then it is on, and else it is off, gives us the ability to ranomly turn the light on and off
        
    }
}
