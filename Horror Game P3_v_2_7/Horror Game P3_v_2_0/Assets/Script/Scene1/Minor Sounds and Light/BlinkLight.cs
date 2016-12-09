using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour {

    Light bLight;
    bool On = true;
    float time = 0.5f;

	// Use this for initialization
	void Start () {
        bLight = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        //made this if statement to ensure that the coroutine is only run once every second.. So that the light will appear to blink
        if(On == true)
        {
            StartCoroutine("Blink");
            On = false;           
        }
        

    }

    
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(time);
        //Makes the light blink the opposite of what it state is, which means, if it is off, it will turn on and vice versa
        bLight.enabled = !bLight.enabled;
        On = true;
    }
    }
