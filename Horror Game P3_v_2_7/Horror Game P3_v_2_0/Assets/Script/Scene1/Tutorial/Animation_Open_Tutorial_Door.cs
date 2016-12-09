using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class Animation_Open_Tutorial_Door : MonoBehaviour {

    //this script is attached to "Scene 1: Tutorial_Section -> prison_crateDoor_b -> prison_cellDoor_a "
    Animation cellDoorOpen;
    tutorialDoor OpenPress;
    bool ready = true;

    void Start()
    {
        GameObject openCellDoor = GameObject.Find("panel_switches");            
        OpenPress = openCellDoor.GetComponent<tutorialDoor>();
        cellDoorOpen = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update () {     
        //Checks that the button (in the tutorial room) has been pressed and then plays the animation to open the door
        //the 'ready' boolean, is only to ensure that the animation will play once, and then stop 
        if(ready == true && OpenPress.buttonPressed == true)
        {
            Debug.Log("PLAYING ANIMATION DOOR");
            cellDoorOpen.Play();
            ready = false;
        }
            
	
	}
}
