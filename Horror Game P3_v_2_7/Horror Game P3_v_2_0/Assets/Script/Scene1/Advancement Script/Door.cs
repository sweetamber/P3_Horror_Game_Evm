using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEditor.Animations;

public class Door : MonoBehaviour
{
    //This script is attached to Scene1: Door_Change_Level
    
    AudioSource audio1;
    public AudioClip Unlocked;
    public AudioClip Locked;

    static GameObject doors;
    static GameObject key;
    static KeyScript keytrigger;
    CharacterController playerMovement; 

    




    void Start()
    {

        //Finds the script for the key, in order to locate a bool that tells you whether or not you picked up the key

        GameObject movement = GameObject.Find("FPSController");
        playerMovement = movement.GetComponent<CharacterController>();

        doors = GameObject.Find("Door");

        key = GameObject.Find("keyObject");

        //this is calls the script component by name
        keytrigger = key.GetComponent<KeyScript>();
        audio1 = GetComponent<AudioSource>();
      

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E) && keytrigger.keycollect == true)
        {
            //Shows that it got hit
            Destroy(doors);
            Debug.Log("Door unlocked!");
            playerMovement.enabled = false;      
            audio1.PlayOneShot(Unlocked);
            StartCoroutine("ShiftScene");
        }

        else if (Input.GetKeyDown(KeyCode.E) && keytrigger.keycollect == false)
            audio1.PlayOneShot(Locked); Debug.Log("Door locked!");
    }


    //Gives the sound for opening the door time to play and disable character movement
    IEnumerator ShiftScene()
    {
        yield return new WaitForSeconds(5);
        playerMovement.enabled = true;
        SceneManager.LoadScene("Scene2");

    }
}
