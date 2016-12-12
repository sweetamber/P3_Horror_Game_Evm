using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Objectives_Scene1 : MonoBehaviour {

    //Access the text field
    Text textToScreen;

    //Accesses varies scripts
    anima OpeningCutScene;
    Tutorial_Events tutorialscript;
    tutorialDoor buttonPressed;
    KeyScript keytrigger;

    bool stage1;
    bool stage2;
    bool stage3;

    AudioSource audio1;


    // Use this for initialization
    void Start () {
        GameObject CutScene = GameObject.Find("LevelOpeningSound");
        OpeningCutScene = CutScene.GetComponent<anima>();

        GameObject tut = GameObject.Find("Tutorial Events");
        tutorialscript = tut.GetComponent<Tutorial_Events>();

        GameObject openCellDoor = GameObject.Find("panel_switches");
        buttonPressed = openCellDoor.GetComponent<tutorialDoor>();

        GameObject key = GameObject.Find("keyObject");
        keytrigger = key.GetComponent<KeyScript>();
        //Access the text component
        textToScreen = GetComponent<Text>();
        audio1 = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

        if (OpeningCutScene.CutSceneRunning == false && stage1 == false)
        {
            textToScreen.enabled = true;
            textToScreen.text = ("Listen to the professor!");
            if (tutorialscript.narrationOver)
            {
                audio1.Play();
                stage1 = true;
            }
        }

        else if (tutorialscript.narrationOver && stage2 == false)
        {
            textToScreen.text = ("Find the Red Button!");
            if(buttonPressed == true)
            {
                audio1.Play();
                stage2 = true;
            }
        }

        else if(buttonPressed.buttonPressed && stage3 == false)
        {
            textToScreen.text = ("Find the key to proceed!");
            if (keytrigger.keycollect)
            {
                audio1.Play();
                stage3 = true;
            }
        }

        else if (keytrigger.keycollect)
        {
            textToScreen.text = ("Proceed deeper into the prison!");
        }
    }
}
