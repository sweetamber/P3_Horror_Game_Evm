using UnityEngine;
using System.Collections;
using System.IO;

public class Stream_Reader_scene2 : MonoBehaviour {

    //Path for the file
    public string filePath = @"C:\evm_data_pulse.txt";

    //Runs the CoRoutine again once it is done, to ensure that it can only be run once
    bool empty;
    //Counts how many times a new string has been read
    int Counter;
    //Parse current into an int
    public float convert;

    public float baseline_Scene1;

   

    // Use this for initialization
    void Start()
    {


    }

    public GameObject scene1_Saved_Object;
    public Stream_Reader_Scene1 script_Scene1;


    // Update is called once per frame
    void Update()
    {
       
        Debug.Log(baseline_Scene1);

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
                convert = float.Parse(sr.ReadLine());
                Debug.Log(convert + " HearthRate");                           
                empty = false;
            } while (empty);
        }
    }
}
