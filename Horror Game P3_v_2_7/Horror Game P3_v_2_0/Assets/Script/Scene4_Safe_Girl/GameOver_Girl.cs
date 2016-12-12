using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver_Girl : MonoBehaviour {

    //This script is attached to Scene4_safe_girl: Event_Trigger
    float seconds = 0;
    float startTime;
    //static Animation animateScriptPlayer;
    public Light fLight;

    AudioSource audio1;
   

    public AudioClip endNarrationSaveGirl;
    public AudioClip lightsOff;

    //Prevent the sounds from playing more than once
    bool Stage1 = false;
    bool Stage2 = false;
    

    bool done = false;

    GameObject ceilingLight1;

    // Use this for initialization
    void Start()
    {
        //Creates an instance of the gameobject where the script we want to access is attached to
        ceilingLight1 = GameObject.Find("Ceiling light1");

        //creates an instance of our player gameobject, so that we can play death animation and also prevent the player from moving while it plays.
        //GameObject deathPlayer = GameObject.Find("FPSController");
        //animateScriptPlayer = deathPlayer.GetComponent<Animation>();

        audio1 = GetComponent<AudioSource>();
        //Resets the timer so that "Seconds starts at zero rather than however long the game has been running, problem with arise you if you just set it to 
        //seconds = Time.time, as the game continues from the previous scene 
        startTime = Time.time;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //Debug.Log(seconds + " D1");

    //    ////Shows what happens when running the counter
    //    Debug.Log(seconds + " Seconds girl");
    //    Debug.Log(Time.time + " Time since startup girl");
    //}

    //unity funtion that check whether or not the gameobject this script is attached to has its collider triggered
    void OnTriggerStay()
    {
        //Times the events happening along with the narration as part of the endScene, light turning of and such 
        seconds = Time.time - startTime;
        //Times the events that happens during the narration
        if (seconds >= 2f && Stage1 == false)
        {
            audio1.Play();
            Stage1 = true;

            Debug.Log(Stage1);
        }

        if (seconds >= 18f && Stage2 == false)
        {
            Stage2 = true;
            audio1.PlayOneShot(lightsOff);
            Destroy(ceilingLight1);
            Debug.Log(Stage2);
        }

        if (seconds >= 25)
        {
            SceneManager.LoadScene("Scene6_Game_End");
        }
    }
}
