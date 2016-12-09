using UnityEngine;
using System.Collections;
using System.IO;

public class Stream_Reader_Scene1 : MonoBehaviour {

    //Path for the file
    public string filePath = @"C:\evm_data_pulse.txt";

    GameObject Reader;
    //Holds the string read from the file
    string current;

    //Runs the CoRoutine again once it is done, to ensure that it can only be run once
    bool empty;
    //Counts how many times a new string has been read
    public int Counter;
    //Parse current into an int
    public float convert;

    public float baseLine;
    float baseLineTemp;

    void Start()
    {
            baseLine = PlayerPrefs.GetFloat("baseline");
            Counter = PlayerPrefs.GetInt("Counter");     
    }

    void OnDestroy()
    {
        PlayerPrefs.SetFloat("baseline", baseLine);
        PlayerPrefs.SetInt("Counter", Counter);
    }

    void OnApplicationQuit()
    {
        //First sets it to zero
        baseLine = 0;
        Counter = 0;
        //then saves the zero value on startUp
        PlayerPrefs.SetFloat("baseline", baseLine);
        PlayerPrefs.SetInt("Counter", Counter);
    }

    // Update is called once per frame
    void Update () {

        if (empty == false)
        {          
            StartCoroutine("WaitAndPrint");
            //Debug.Log("StreamReader Initialized");
            //Debug.Log(empty + " Not Empty");
            empty = true;
        }
    }


    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(1);

        using (StreamReader sr = new StreamReader(filePath))
        {          
            do
            {
                current = sr.ReadLine();
                convert = float.Parse(current);
                //Debug.Log(current + " HearthRate");                

                if (Counter <= 3)
                {
                    Debug.Log(Counter + " " + baseLineTemp + " HR BaseLine After 60");
                    Counter++;
                    if (Counter < 3)
                    {
                        
                        baseLineTemp = baseLineTemp + convert;
                    }
                    if (Counter == 3)
                    {
                        baseLine = baseLineTemp / 3;
                        Debug.Log("Baseline: " + baseLine);
                    }
                }           
                empty = false;
            } while (empty);
        }
    }
}

