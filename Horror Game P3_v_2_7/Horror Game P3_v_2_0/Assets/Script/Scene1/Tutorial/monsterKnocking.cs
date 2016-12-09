using UnityEngine;
using System.Collections;

public class monsterKnocking : MonoBehaviour {

    public float timeTriggerEvents = 5;
    public bool once = true;

    AudioSource audio1;
        Tutorial_Events buttonTrigger;

    // Use this for initialization
    void Start()
    {
        GameObject button = GameObject.Find("Tutorial Events");
        buttonTrigger = button.GetComponent<Tutorial_Events>();
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (once && buttonTrigger.narrationOver == true){
        Debug.Log("Started");
        StartCoroutine("MonsterDoor");
        once = false;
    }

    }


 
    IEnumerator MonsterDoor()
    {
        yield return new WaitForSeconds(timeTriggerEvents);
        audio1.Play();
    }
}
