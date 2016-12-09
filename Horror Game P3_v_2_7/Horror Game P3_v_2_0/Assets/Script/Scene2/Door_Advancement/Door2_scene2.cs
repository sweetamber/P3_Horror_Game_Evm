using UnityEngine;
using System.Collections;

public class Door2_scene2 : MonoBehaviour {

    //This script is attached to scene2: Door_Opening_System --> Door-key_1 --> Door_1

    AudioSource audio1;
    public AudioClip Unlocked;
    public AudioClip Locked;

    //static GameObject doors;
    static GameObject key;
    static keyScript2_scene2 keytrigger;

    Animation DoorOpening;
    //to ensure the opening animation can only play once
    bool playOnceOpen = false;


    void Start()
    {
        //doors = GameObject.Find("Door_2");

        key = GameObject.Find("keyObject2");

        //this is calls the script component by name
        keytrigger = key.GetComponent<keyScript2_scene2>();

        audio1 = GetComponent<AudioSource>();

        DoorOpening = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E) && keytrigger.keycollect == true && playOnceOpen == false)
        {
            //Shows that it got hit          
            Debug.Log("Door unlocked2!");
            audio1.PlayOneShot(Unlocked);
            StartCoroutine("ShiftScene");
            playOnceOpen = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && keytrigger.keycollect == false)
            audio1.PlayOneShot(Locked); Debug.Log("Door locked2!");
    }

    IEnumerator ShiftScene()
    {
        yield return new WaitForSeconds(0);
        DoorOpening.Play();
    }
}
