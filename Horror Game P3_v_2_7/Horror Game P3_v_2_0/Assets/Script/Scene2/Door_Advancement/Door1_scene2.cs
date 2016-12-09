using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class Door1_scene2 : MonoBehaviour {

    //This script is attached to scene2: Door_Opening_System --> Door-key_1 --> Door_1

    AudioSource audio1;
    public AudioClip Unlocked;
    public AudioClip Locked;

    //static GameObject doors;
    static GameObject key;
    static keyScript1_scene keytrigger;

    Animation DoorOpening;
    //to ensure the opening animation can only play once
    bool playOnceOpen = false;


    void Start()
    {       
        //doors = GameObject.Find("Door_1");

        key = GameObject.Find("keyObject1");

        //this is calls the script component by name
        keytrigger = key.GetComponent<keyScript1_scene>();

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
            Debug.Log("Door unlocked!");
            audio1.PlayOneShot(Unlocked);
            StartCoroutine("ShiftScene");
            playOnceOpen = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && keytrigger.keycollect == false)
            audio1.PlayOneShot(Locked); Debug.Log("Door locked!");
    }

    IEnumerator ShiftScene()
    {
        yield return new WaitForSeconds(3);
        //playerMovement.enabled = true;
        DoorOpening.Play();
    }
}
