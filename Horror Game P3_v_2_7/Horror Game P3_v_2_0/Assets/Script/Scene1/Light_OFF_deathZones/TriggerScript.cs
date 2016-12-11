using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{

    // this script is attached to "Scene 1: Scene1 -> Lamps_Ceiling -> Lamps_Hallway -> prisonLamp_b_shortA2 -> Ceiling light1 "
    public float speedOfLight;

    Light[] lights = new Light[5];

    Light tutorial_light;
    AudioSource audio1;
    public AudioClip secondNarrative;

    Stream_Reader_Scene1 HR;


    bool flag = true;
    //Booleans for turning of the light in the scene
    public bool ceiling0_Off_Tutorial = false;
    public bool ceiling1_Off = false;
    public bool ceiling2_Off = false;
    public bool ceiling3_Off = false;
    public bool ceiling4_Off = false;
    public bool ceiling5_Off = false;

    //The minimum and maximum speed of light
    public float maxSpeedOfLight = 20;
    public float minSpeedOfLight = 5;

    static GameObject ceiling1;

    void Start()
    {
        audio1 = GetComponent<AudioSource>();

        //Calls all the lights in a scene
        GameObject ceiling0_tutorial = GameObject.Find("Ceiling light_tutorial");
        GameObject ceiling1 = GameObject.Find("Ceiling light1");
        GameObject ceiling2 = GameObject.Find("Ceiling light2");
        GameObject ceiling3 = GameObject.Find("Ceiling light3");
        GameObject ceiling4 = GameObject.Find("Ceiling light4");
        GameObject ceiling5 = GameObject.Find("Ceiling light5");

        //Acceses the different lights in the scene and saves them in an array of light component variables
        tutorial_light = ceiling0_tutorial.GetComponent<Light>();
        lights[0] = ceiling1.GetComponent<Light>();
        lights[1] = ceiling2.GetComponent<Light>();
        lights[2] = ceiling3.GetComponent<Light>();
        lights[3] = ceiling4.GetComponent<Light>();
        lights[4] = ceiling5.GetComponent<Light>();

        GameObject Reader = GameObject.Find("Stream_Reader1");
        HR = Reader.GetComponent<Stream_Reader_Scene1>();
       
    }

    IEnumerator ShutDown()
    {
        //Runs through the array of light component and turnning them off one by one, all depended on the time passed between each
        for (int i = 0; i <= lights.Length; i++)
        {
            yield return new WaitForSeconds(speedOfLight);
            lights[i].intensity = 0;
            audio1.Play();
            if (i == 0)
            { ceiling1_Off = true; Debug.Log("C1 = true"); calculateLight(); }
            else if (i == 1)
            { ceiling2_Off = true; Debug.Log("C2 = true"); calculateLight(); }
            else if (i == 2)
            { ceiling3_Off = true; Debug.Log("C3 = true"); calculateLight(); }
            else if (i == 3)
            { ceiling4_Off = true; Debug.Log("C4 = true"); calculateLight(); }
            else if (i == 4)
            { ceiling5_Off = true; Debug.Log("C5 = true"); calculateLight(); }
        }
    }

    //Happens only on the first light you exit, This triggers all other lights to go off and also trigger narration associated with the tutorial level
    //as well as the light in the tutorial level
    void OnTriggerExit()
    {
        if (flag)
        {
            ceiling0_Off_Tutorial = true; Debug.Log("C0_tutorial = true");
            tutorial_light.intensity = 0;
            audio1.Play();
            audio1.PlayOneShot(secondNarrative);
            calculateLight();
            StartCoroutine("ShutDown");
            flag = false;
        }
    }

    //What happens if you lose(Restart level)
    public void gameStateOver()
    {
        SceneManager.LoadScene("Scene1");
    }

    void calculateLight()
    {
        if (PlayerPrefs.GetInt("ON_OFF") != 0)
        {
            //Basically, if the player is 10 procent more scared than when he started the game, he will have 10 procent of seconds subtracted from the speed of light

            //The procent different between baseline and current hearthrate
            float procentDifferenceInCurrentHR = 0;
            //One procent of Maximum light speed, adjust from 100 to 0>value to increase difficulty, the lower the number, the more seconds will be cut off
            float oneProcentOfMaxSpeed = maxSpeedOfLight / 60;
            //holds the subtracted value of % difference in seconds
            float subtractSpeed = 0;

            procentDifferenceInCurrentHR = 0;
            subtractSpeed = 0;

            //HR calculations-----------------------------------------    
            //Calculates the procent difference from the baseLine and the current HR i.e. 10 procent difference(10 procent more scared).
            //Formula found at http://www.calculatorsoup.com/calculators/algebra/percent-difference-calculator.php
            procentDifferenceInCurrentHR = (HR.convert - HR.baseLine) / (HR.convert + HR.baseLine / 2) * 100;

            //Light calculations--------------------------------------------   
            //Then it takes the procent difference between hearthrate and finds out how many seconds i.e. 10 procent increased hearthrate is in seconds 
            subtractSpeed = oneProcentOfMaxSpeed * procentDifferenceInCurrentHR;
            //It then substracts the amount of seconds equal to i.e. 10 procent of the maximum speed of light and then defines a new speed.
            speedOfLight = maxSpeedOfLight - subtractSpeed;

            if (speedOfLight < 5)
            {
                speedOfLight = 5;
            }

            if (speedOfLight > 20)
            {
                speedOfLight = 20;
            }

            //Printing the values
            Debug.Log(oneProcentOfMaxSpeed + " one Procent Max Speed");
            Debug.Log(procentDifferenceInCurrentHR + " Procent Difference in HR");
            Debug.Log(subtractSpeed + " Seconds subtracted");
            Debug.Log(speedOfLight + " New Light Speed");
        }
    }
}


