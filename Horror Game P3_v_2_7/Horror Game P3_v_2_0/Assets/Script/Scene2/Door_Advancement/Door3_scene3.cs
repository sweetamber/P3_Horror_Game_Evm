using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class Door3_scene3 : MonoBehaviour {
    //This script is attached to scene2: Door_Opening_System --> Door-key_3(Office) --> Door_3

    AudioSource audio1;
    public AudioClip Unlocked;
    public AudioClip Locked;

    //static GameObject doors;
    static GameObject key;
    static keyScript_scene3 keytrigger;

    Animation DoorOpening;
    //to ensure the opening animation can only play once
    bool playOnceOpen = false;


    void Start()
    {
        //doors = GameObject.Find("Door_2");

        key = GameObject.Find("keyObject3");

        //this is calls the script component by name
        keytrigger = key.GetComponent<keyScript_scene3>();

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
        yield return new WaitForSeconds(3);
        DoorOpening.Play();
    }
}
