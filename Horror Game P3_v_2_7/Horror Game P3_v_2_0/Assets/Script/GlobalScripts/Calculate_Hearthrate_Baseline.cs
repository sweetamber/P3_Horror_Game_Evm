using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Calculate_Hearthrate_Baseline : MonoBehaviour {

    //Stream_reader script
    Stream_Reader_Scene1 Access_Stream;

    //Text access
    Text secondsRemaining;

	// Use this for initialization
	void Start () {

        //Find gameobjects
        GameObject seconds = GameObject.Find("Seconds");
        GameObject stream = GameObject.Find("Stream_Reader1");

        //Find components of specific gameobjects
        Access_Stream = stream.GetComponent<Stream_Reader_Scene1>();
        secondsRemaining = seconds.GetComponent<Text>();

	
	}
	
	// Update is called once per frame
	void Update () {

        //Write the seconds remainning to canvas through its component variable. 
        secondsRemaining.text = (Access_Stream.Counter + "/" + Access_Stream.baselineCalc_Length);
	
	}
}
