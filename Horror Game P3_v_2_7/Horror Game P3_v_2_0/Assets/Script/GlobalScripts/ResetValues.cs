using UnityEngine;
using System.Collections;

public class ResetValues : MonoBehaviour {

    //Resets all saved values, so that the game may be run again without any playerPref 
    //values, such as baseline_HR values or tutorial narration being remembered as played already once.
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
