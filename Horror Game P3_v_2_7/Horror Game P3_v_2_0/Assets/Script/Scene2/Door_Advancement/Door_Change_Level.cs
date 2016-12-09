using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door_Change_Level : MonoBehaviour {

    //This script is attached to scene2: Door_Opening_System --> Door-key_1 --> Door_1

    AudioSource audio1;
    public AudioClip Unlocked;
    public AudioClip Locked;

    //static GameObject doors;
    static GameObject key;
    static keyScript_Advancement keytrigger;

    CharacterController playerMovement;

    Animation DoorOpening;
    //to ensure the opening animation can only play once
    bool playOnceOpen = false;


    void Start()
    {


        GameObject movement = GameObject.Find("FPSController");
        playerMovement = movement.GetComponent<CharacterController>();

        //doors = GameObject.Find("Door_1");

        key = GameObject.Find("keyObject_scene3");

        //this is calls the script component by name
        keytrigger = key.GetComponent<keyScript_Advancement>();

        audio1 = GetComponent<AudioSource>();

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
            playerMovement.enabled = false;
            audio1.PlayOneShot(Unlocked);
            StartCoroutine("ShiftScene");
            playOnceOpen = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && keytrigger.keycollect == false)
            audio1.PlayOneShot(Locked); Debug.Log("Door locked!");
    }

    IEnumerator ShiftScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Scene3");

    }
}
