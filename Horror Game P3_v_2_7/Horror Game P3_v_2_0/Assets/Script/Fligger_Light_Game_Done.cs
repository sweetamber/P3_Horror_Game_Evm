using UnityEngine;
using System.Collections;

public class Fligger_Light_Game_Done : MonoBehaviour {

    // this script is attached to "Scene 2: Scene2 -> Lamps -> HallWayLight -> Ceiling light_HallWay "

    public float speedOfFligger;
    int fliggering;
    bool playOnce;

    Light lights;

    bool flag = true;


    void Start()
    {
        lights = GetComponent<Light>();

    }


    void Update()
    {
        //Booleans make stops the loop (Update), so to many won't be active at a time
        if (playOnce == false)
            StartCoroutine("Environment_fligger"); playOnce = true;

    }


    IEnumerator Environment_fligger()
    {

        yield return new WaitForSeconds(speedOfFligger);
        //Makes the light change its range consistently, thus making the illusion of fliggering light, place these 2 lines in the update and you will see flickering as well
        //Couroutine, was just made to slow the flickering down, match it better with sound_effect

        //by placing playOnce before determining the light, we start a coroutine before it is decides if the light is on or off, this gives the light a more random flickering
        //rather than a flickering that appears to be timed.
        playOnce = false;

        //Basically just takes a random value between 0,1, if its lower than 0.5f, then it is on, and else it is off, gives us the ability to ranomly turn the light on and off
        if (Random.value < 0.5f)
        {
            //fliggering = Random.Range(5, 10);
            lights.range = 70;
        }
        else
            lights.range = 90;


    }
}
