using UnityEngine;
using System.Collections;

public class keyScript_Advancement : MonoBehaviour {
    AudioSource audio1;
    static GameObject key;
    public bool keycollect;
    float time = 0.5f;


    void Start()
    {
        key = GameObject.Find("keyObject_scene3");
        audio1 = key.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audio1.Play();
            Debug.Log("Key Collected! " + keycollect);
            keycollect = true;
            StartCoroutine("KeySound");

        }
    }

    //This was used so that the sound would have time to play before the object was destroyed.
    IEnumerator KeySound()
    {
        yield return new WaitForSeconds(time);
        Destroy(key);
        Debug.Log("Key collected!");
    }
}
