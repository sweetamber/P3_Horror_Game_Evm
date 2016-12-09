using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaveSister_Ending : MonoBehaviour {


    //This script is attached to scene3: BlackDoor_Ending--> prison_door_a2
    

        //This script checks whether or not the narration in scene is done, furthermore it Specifies which chice the player has made by
        //Directing them to a specified scene

    AudioSource audio1;
    public AudioClip Unlocked;
    public AudioClip Locked;

    //static GameObject doors;
    static GameObject key;
    static EndSceneTrigger keytrigger;

    bool playOnceOpen = false;
    CharacterController playerMovement;


    void Start()
    {


        GameObject movement = GameObject.Find("FPSController");
        playerMovement = movement.GetComponent<CharacterController>();

        //doors = GameObject.Find("Door_1");

        key = GameObject.Find("EndScene_trigger");

        //this is calls the script component by name
        keytrigger = key.GetComponent<EndSceneTrigger>();

        audio1 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E) && keytrigger.narrationOver == true && playOnceOpen == false)
        {
            //Shows that it got hit          
            Debug.Log("Door unlocked!");
            playerMovement.enabled = false;
            audio1.PlayOneShot(Unlocked);
            StartCoroutine("ShiftScene");
            playOnceOpen = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && keytrigger.narrationOver == false)
            audio1.PlayOneShot(Locked); Debug.Log("Door locked!");
    }

    IEnumerator ShiftScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scene4_save_girl");

    }
}
