using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class Stream_Reader_Scene1 : MonoBehaviour {

    //Path for the file
    public string filePath = @"C:\evm_data_pulse.txt";

    GameObject Reader;
    //Holds the string read from the file
    string current;

    public bool On_Off = true;

    //Runs the CoRoutine again once it is done, to ensure that it can only be run once
    bool empty;
    //Counts how many times a new string has been read
    public int Counter;
    //Parse current into an int
    public float convert;

    public float baseLine;
    float baseLineTemp;

    public int baselineCalc_Length;

    //This happens everytime the scene is loaded, if the following two lines is put in the start(), then it will only be called once, thus resetting the baseline 
    //values everytime the scene is restarted()
    void Awake()
    {
        if (PlayerPrefs.GetInt("ON_OFF") != 0)
            {
            baseLine = PlayerPrefs.GetFloat("baseline");
            Counter = PlayerPrefs.GetInt("Counter");
            //Debug.Log(baseLine);
            //Debug.Log(Counter);
        }
    }



    void OnDestroy()
    {
        if (PlayerPrefs.GetInt("ON_OFF") != 0)
        {
            //saves the baseline and counter, right before the gameobject gets destroyed... Happens whenever the scene is ended.. Whether it is scene0, 1, 2... Since the game
            //Object exist in them all
            PlayerPrefs.SetFloat("baseline", baseLine);
            PlayerPrefs.SetInt("Counter", Counter);
        }
    }

    // Update is called once per frame
    void Update () {

        if (empty == false && PlayerPrefs.GetInt("ON_OFF") != 0)
        {      
            //Runs coroutine that runs every second and takes a stored value from a textFile    
            StartCoroutine("WaitAndPrint");
            empty = true;
        }
    }

    IEnumerator WaitAndPrint()
    {
        if (PlayerPrefs.GetInt("ON_OFF") != 0)
        {
            yield return new WaitForSeconds(1);

            using (StreamReader sr = new StreamReader(filePath))
            {
                //a loop not unlike the while loop... It says, 'do' while empty = true. Runs only the code between the do and while statement.     
                do
                {
                    //First convert the string saved int the document found in the path (filePath)
                    convert = float.Parse(sr.ReadLine());

                    //While the counter is less than 60 (or whatever) it increments the baselineCalc_Length every Second
                    if (Counter <= baselineCalc_Length)
                    {
                        Debug.Log(Counter + " " + baseLineTemp + " HR BaseLine After 60");
                        Counter++;
                        //Adds the current HR with the previous and adds them together... Used to calculate the average value of 60 HR outputs
                        if (Counter < baselineCalc_Length)
                        {
                            baseLineTemp = baseLineTemp + convert;
                        }
                        //When the 60 seconds has passed, take all the 60 HR values added together and divide by the number of HR values (60), thus finding the average and then 
                        //switch to scene1 (Starts the game)
                        if (Counter == baselineCalc_Length)
                        {
                            baseLine = baseLineTemp / baselineCalc_Length;
                            Debug.Log("Baseline: " + baseLine);
                            SceneManager.LoadScene("Scene1");
                        }
                    }
                    empty = false;
                } while (empty);
            }
        }
    }

    //When the application ends, reset the values baseline and counter... So that a new can be calculated next time the game is started
    //defines 2 new values (0), and then saves them 
    void OnApplicationQuit()
    {
        baseLine = 0;
        Counter = 0;
        PlayerPrefs.SetFloat("baseline", baseLine);
        PlayerPrefs.SetInt("Counter", Counter);
    }
}

