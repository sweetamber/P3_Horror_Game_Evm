using UnityEngine;
using System.Collections;

public class FlashOnOff : MonoBehaviour {

    AudioSource audio1;
    public Light fLight;


    // Use this for initialization
    void Start () {
        
        fLight = GetComponent<Light>();
        audio1 = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {  
        
        if(Input.GetKeyDown(KeyCode.F))
          {
            fLight.enabled = !fLight.enabled;
            audio1.Play();
        }
    }
}
