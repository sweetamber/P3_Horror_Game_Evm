using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Objectives_Scene2 : MonoBehaviour
{
    //Access the text field
    Text textToScreen;

    //Finds all the keyscripts, so that we may call booleans to determine whether or not they have been collected
    keyScript1_scene keytrigger1;
    keyScript2_scene2 keytrigger2;
    keyScript_scene3 keytrigger3;
    keyScript_Advancement keytrigger4;



    bool stage1;
    bool stage2;
    bool stage3;

    AudioSource audio1;

    int amountOFKeys;

    // Use this for initialization
    void Start()
    {
        //Tells the program where to find scripts
        GameObject key1 = GameObject.Find("keyObject1");
        keytrigger1 = key1.GetComponent<keyScript1_scene>();

        GameObject key2 = GameObject.Find("keyObject2");
        keytrigger2 = key2.GetComponent<keyScript2_scene2>();

        GameObject key3 = GameObject.Find("keyObject3");
        keytrigger3 = key3.GetComponent<keyScript_scene3>();

        GameObject key4 = GameObject.Find("keyObject_scene3");
        keytrigger4 = key4.GetComponent<keyScript_Advancement>();


        //Access the text component
        textToScreen = GetComponent<Text>();
        audio1 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Since the keyScripts are attached to an object which is destroyed when picked up, we can just allow it to continue on without calling additional booleans

        //When the 1 key is not collected
        if (keytrigger1.keycollect == false)
        {
            textToScreen.text = ("0/4 keys found, find the first key, it might be close");
        }

        //When the 2 key is not collected
        else if (keytrigger2.keycollect == false)
        {
            textToScreen.text = ("1/4 keys found, find the door that fits the key!");
     
        }

        //When the 3 key is not collected
        else if (keytrigger3.keycollect == false)
        {
            textToScreen.text = ("2/4 keys found, this key looks different, might be for a different type of door!");
       
        }

        //When the 4 key is not collected
        else if (keytrigger4.keycollect == false)
        {
            textToScreen.text = ("3/4 keys found, find the door that fits the key!");       
        }
        //This is also why we call the last objective like this, since there is no more keys or booleans to trigger, we can proceed
        else
        {
            textToScreen.text = ("4/4 keys found, Proceed Deeper into the prison!");
        }
    }
}