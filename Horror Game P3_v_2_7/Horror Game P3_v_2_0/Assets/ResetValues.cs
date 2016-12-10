using UnityEngine;
using System.Collections;

public class ResetValues : MonoBehaviour {

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
