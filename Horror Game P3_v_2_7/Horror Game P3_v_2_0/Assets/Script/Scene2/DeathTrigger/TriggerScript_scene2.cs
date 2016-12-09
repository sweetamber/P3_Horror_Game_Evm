using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerScript_scene2 : MonoBehaviour {


    // this script is attached to "Scene 2: Scene2 -> Room_2_Floor_2 -> Lamps -> prisonLamp_b_long1 -> Ceiling light1 "

    //The following script is a true copy of the triggerScript from scene1, can be located in Project: -->scripts-->scene1--> Light_OFF_deathZones
    //The functionality is explained more in detail there


    public float speedOfLight;

    Light[] lights = new Light[7];

    Light tutorial_light;
    AudioSource audio1;

    Stream_Reader_Scene1 HR;


    bool flag = true;
    public bool ceiling1_Off = false;
    public bool ceiling2_Off = false;
    public bool ceiling3_Off = false;
    public bool ceiling4_Off = false;
    public bool ceiling5_Off = false;
    public bool ceiling6_Off = false;

    //The minimum and maximum speed of light
    public float maxSpeedOfLight = 20;
    public float minSpeedOfLight = 5;

    static GameObject ceiling1;

    void Start()
    {

        audio1 = GetComponent<AudioSource>();

        GameObject ceiling1 = GameObject.Find("Ceiling light1");
        GameObject ceiling2 = GameObject.Find("Ceiling light2");
        GameObject ceiling3 = GameObject.Find("Ceiling light3");
        GameObject ceiling4 = GameObject.Find("Ceiling light4");
        GameObject ceiling5 = GameObject.Find("Ceiling light5");
        GameObject ceiling6 = GameObject.Find("Ceiling light6");


        lights[0] = ceiling1.GetComponent<Light>();
        lights[1] = ceiling2.GetComponent<Light>();
        lights[2] = ceiling3.GetComponent<Light>();
        lights[3] = ceiling4.GetComponent<Light>();
        lights[4] = ceiling5.GetComponent<Light>();
        lights[5] = ceiling6.GetComponent<Light>();

        GameObject Reader = GameObject.Find("Stream_Reader1");
        HR = Reader.GetComponent<Stream_Reader_Scene1>();
    }


    void Update()
    {
        //Debug.Log("FUCK");

        //int fliggering = Random.Range(5, 15);
        //lights[2].range = fliggering;
    }

    IEnumerator ShutDown()
    {
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
            else if (i == 5)
            { ceiling6_Off = true; Debug.Log("C6 = true"); calculateLight(); }
        }
    }


    void OnTriggerExit()
    {
        if (flag)
        {
            calculateLight();
            StartCoroutine("ShutDown");
            flag = false;
        }
    }


    public void gameStateOver()
    {
        SceneManager.LoadScene("Scene2");
    }
    void calculateLight()
    {
        //Basically, if the player is 10 procent more scared than when he started the game, he will have 10 procent of seconds subtracted from the speed of light

        //The procent different between baseline and current hearthrate
        float procentDifferenceInCurrentHR = 0;
        //One procent of light speed
        float oneProcentOfMaxSpeed = maxSpeedOfLight / 100;
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

        //Printing the values
        Debug.Log(HR.baseLine +  " baseLine");
        Debug.Log(procentDifferenceInCurrentHR + " Procent Difference in HR");
        Debug.Log(subtractSpeed + " Seconds subtracted");
        Debug.Log(speedOfLight + " New Light Speed");
    }

}
