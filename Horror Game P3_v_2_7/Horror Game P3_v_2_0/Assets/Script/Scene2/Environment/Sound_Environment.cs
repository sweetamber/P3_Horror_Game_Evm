using UnityEngine;
using System.Collections;

public class Sound_Environment : MonoBehaviour {

    //This script can be found in Scene2: Environmental_Sounds --> RandomSounds

    public float speedOfSounds = 10;
    bool PlayOnce = false;

    AudioSource audio1;


    //Stores 4 audioClips in an array
    AudioClip[] scarySounds = new AudioClip[4];

    TriggerScript_scene2 lightOutAccess;

    public AudioClip scary1;
    public AudioClip scary2;
    public AudioClip scary3;
    public AudioClip scary4;


    // Use this for initialization
    void Start () {

        //allow us to import sounds into the script (Gets the component of the game object)
        audio1 = GetComponent<AudioSource>();

        //Creates an instance of the gameobject where the script we want to access is attached to
        GameObject ceilingLight1 = GameObject.Find("Ceiling light1");
        //Gets the script component so that unity can find it
        lightOutAccess = ceilingLight1.GetComponent<TriggerScript_scene2>();


        //Defines the index position of the array with variables of audioclips
        scarySounds[0] = scary1;
        scarySounds[1] = scary2;
        scarySounds[2] = scary3;
        scarySounds[3] = scary4;


    }
	
	// Update is called once per frame
	void Update () {

        // if the first light have been turned off, then start a counter, which plays a new sound every
        //Specified amount of seconds...
        if (lightOutAccess.ceiling1_Off && PlayOnce == false)
        {
            StartCoroutine("Environment_Sounds"); Debug.Log("COROUTINE_STARTED!");
        }
    }

    //Builds on the same principle as the TriggerScripts turning off the lights
    IEnumerator Environment_Sounds()
    {
        Debug.Log(PlayOnce);
        PlayOnce = true;
        for (int i = 0; i <= scarySounds.Length; i++)
        {
            yield return new WaitForSeconds(speedOfSounds);         
            audio1.PlayOneShot(scarySounds[i]);
            Debug.Log("PLAYED!");
            Debug.Log(PlayOnce);

            if (i == 3)
            {
                i = 0;
            }
        }
    }
}
