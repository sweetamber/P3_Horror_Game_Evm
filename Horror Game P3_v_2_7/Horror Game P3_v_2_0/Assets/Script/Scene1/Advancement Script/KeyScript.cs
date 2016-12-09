using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour
{
    //This script is attached to Scene1: Door_Change_Level -->keyObject 

    AudioSource audio1;
    static GameObject key;
    public bool keycollect;
    float time = 0.5f;


    void Start()
    {
        key = GameObject.Find("keyObject");
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
            StartCoroutine("KeySound");
            keycollect = true;            
           
        }
    }

    IEnumerator KeySound()
    {
        yield return new WaitForSeconds(time);
        Destroy(key);
        Debug.Log("Key collected!");
    }

}
