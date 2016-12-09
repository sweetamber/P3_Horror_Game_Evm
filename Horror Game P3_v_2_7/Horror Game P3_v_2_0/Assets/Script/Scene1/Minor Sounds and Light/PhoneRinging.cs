using UnityEngine;
using System.Collections;

public class PhoneRinging : MonoBehaviour {

    //This script is attached to "Scene 1: JumpScare -> Phone"

    AudioSource audio1;
    bool TriggerNotActive = true;
    static JumpScare_lvl1 EndPhoneCall;


    // Use this for initialization
    void Start () {
        //Creates an instance of the gameobject where the script we want to access is attached to
        GameObject Jumpscare = GameObject.Find("JumpScare");
        //Gets the script component so that unity can find it
        EndPhoneCall = Jumpscare.GetComponent<JumpScare_lvl1>();

        audio1 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (TriggerNotActive == true && EndPhoneCall.counter < 1)
        {
            StartCoroutine("Phone");
            TriggerNotActive = false;
        }

    }

    IEnumerator Phone()
    {
        yield return new WaitForSeconds(5);
        audio1.Play();
        TriggerNotActive = true;

    }
}
