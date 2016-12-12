using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Objectives_Scene3 : MonoBehaviour
{

    //Access the text field
    Text textToScreen;
    EndSceneTrigger scene3_Trigger_Script;

    // Use this for initialization
    void Start()
    {
        GameObject Scene3 = GameObject.Find("EndScene_trigger");
        scene3_Trigger_Script = Scene3.GetComponent<EndSceneTrigger>();

        textToScreen = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (scene3_Trigger_Script.narrationOver == false)
        {
          
            textToScreen.text = ("Listen to the professor!");
           
        }
        else if (scene3_Trigger_Script.narrationOver == true)
        {
            textToScreen.text = ("Make your Choice! YellowDoor saves youself. BlackDoor, Saves your sister");
        }
    }

}