using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaveSelf_Ending : MonoBehaviour {

    //This script is attached to scene3: YellowDoor_Ending --> prison_door_a2 yellow
    AudioSource audio1;
    public AudioClip Unlocked;
    public AudioClip Locked;

    //static GameObject key;
    static GameObject key;
    static EndSceneTrigger keytrigger;

    bool playOnceOpen = false;
    CharacterController playerMovement;


    void Start()
    {
        //To disable character movement while opening doors.
        GameObject movement = GameObject.Find("FPSController");
        playerMovement = movement.GetComponent<CharacterController>();

        //Allows you to access the EndScene_trigger, thus giving you the possibility of knowing when the narration is over via referencing a bool from that script. 
        //This is to make sure that the player don't choose(By accident or on purpose) to open doors before the narration is over
        key = GameObject.Find("EndScene_trigger");

        //this is calls the script component by name
        keytrigger = key.GetComponent<EndSceneTrigger>();

        //Accesses audioSource component
        audio1 = GetComponent<AudioSource>();

    }

    void OnTriggerStay()
    {
        //When narration is done and you press e by one of the doors.
        if (Input.GetKeyDown(KeyCode.E) && keytrigger.narrationOver == true && playOnceOpen == false)
        {
            //Disables the playerMovement and plays the unlockDoor audio, starts a coroutine that gives the sound 5 seconds to finish before changing scene. The bool is to make sure you cannot
            //Spam this if statement.       
            //Debug.Log("Door unlocked!");
            playerMovement.enabled = false;
            audio1.PlayOneShot(Unlocked);
            StartCoroutine("ShiftScene");
            playOnceOpen = true;
        }
        //When narration is not done, and you press e by one of the doors
        else if (Input.GetKeyDown(KeyCode.E) && keytrigger.narrationOver == false)
            audio1.PlayOneShot(Locked); Debug.Log("Door locked!");
    }

    //Counts 5 seconds and then change to the appropriate scene
    IEnumerator ShiftScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scene5_save_myself");

    }
}
