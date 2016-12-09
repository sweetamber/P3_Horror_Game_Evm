using UnityEngine;
using System.Collections;

public class tutorialDoor : MonoBehaviour {
    //this script is attached to "Scene 1: Tutorial_Section -> Tutorial_Prefabs -> panel_Switches

    AudioSource audio1;
    GameObject button;
    public AudioClip buttonAudio;
    public AudioClip cellDoorSound;
    float time = 0.2f;

    // used to tell the "Animation_Open_Tutorial_Door.cs that the button has been pressed, so that it can run the animation for opening it
    public bool buttonPressed = false;

    //access the button trigger script
    Tutorial_Events buttonTrigger;


    void Start()
    {
        button = GameObject.Find("Tutorial Events");
        audio1 = button.GetComponent<AudioSource>();
        buttonTrigger = button.GetComponent<Tutorial_Events>();

    }

    void Update()
    {

    }

    void OnTriggerStay()
    {
        //checks if player is pressing e and if the narration is over
        if (Input.GetKeyDown(KeyCode.E) && buttonTrigger.narrationOver == true)
        {
            audio1.PlayOneShot(buttonAudio);
            buttonTrigger.narrationOver = false;
            buttonPressed = true;
            StartCoroutine("buttonSound");         
        }
    }

    IEnumerator buttonSound()
    {
        yield return new WaitForSeconds(time);     
        audio1.PlayOneShot(cellDoorSound);
        Debug.Log("button Pressed!");
    }
}
