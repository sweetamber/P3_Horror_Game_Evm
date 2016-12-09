using UnityEngine;
using System.Collections;

public class EndScene_Chair_Flickering : MonoBehaviour {

    // this script is attached to "Scene 4_save_girl: prisonLamp_b_shortA2-> Ceiling light1"

        //Time of the coroutine
    public float speedOfFligger;
        //Used to ensure that coroutine will only play once
    bool playOnce;

    //Variable for light component
    Light lights;

    //Accesses components and gameobject on startup
    void Start()
    {
        lights = GetComponent<Light>();
    }


    void Update()
    {
        //Booleans make stops the loop (Update), so to many won't be active at a time
        if (playOnce == false)
        {
            //Used to make the light fligger not in sequence but more randomly/realisticly
            speedOfFligger = Random.Range(0.1f,0.3f);
            StartCoroutine("Environment_fligger");
            //Ends the loop effect for this if statement
            playOnce = true;
        }

    }

    IEnumerator Environment_fligger()
    {

        yield return new WaitForSeconds(speedOfFligger);
        //Makes the light change its range consistently, thus making the illusion of fliggering light, place these 2 lines in the update and you will see flickering as well
        //Couroutine, was just made to slow the flickering down, match it better with sound_effect
        if (Random.value < 0.5f)
        {
            //fliggering = Random.Range(5, 10);
            lights.range = 10;
        }
        else
            lights.range = 3;

        //Allows the coroutine to play again once it is finished, so that the update won't loop
        playOnce = false;
    }

}
