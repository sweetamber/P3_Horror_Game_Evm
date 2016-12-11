using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EVM_On_Off : MonoBehaviour
{
    int On_Or_Off = 1;

    // Update is called once per frame

        void Start()
    {
        PlayerPrefs.GetInt("Counter", On_Or_Off);
    }
    void Update()
    {
        //Allows you to turn off the functions in a script accross scenes. Since the On_Or_Off value is saved as one, it will then tell the streamWriter not to run. 
        //The streamWriter requires the value ON_OFF in player.Prefs to be anything else than 1 to have any working functions
        if (Input.GetKeyDown(KeyCode.F10))
        {
            On_Or_Off = 0;
            PlayerPrefs.SetInt("ON_OFF", On_Or_Off);
            SceneManager.LoadScene("Scene1");
        }
        //Sets the value to 1 and runs the hearthrate calculations again
        if (Input.GetKeyDown(KeyCode.F11))
        {
            On_Or_Off = 1;
            PlayerPrefs.SetInt("ON_OFF", On_Or_Off);
            SceneManager.LoadScene("Scene0_Evm_Calibration");
        }
    }

    //When the application ends, reset the value on or off..
    //Resets the value to default when the game ends
    void OnApplicationQuit()
    {
        On_Or_Off = 1;
        PlayerPrefs.SetInt("ON_OFF", On_Or_Off);
    }
}
