using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class JumpScare_lvl1 : MonoBehaviour
{
    //this script is attached to "Scene 1: JumpScare"

    public int counter;
  

    GameObject Monster;
    AudioSource audio1;
   

    Animation MonsterWindow;

    // Use this for initialization
    void Start()
    {

        Monster = GameObject.Find("z@walk");
        MonsterWindow = Monster.GetComponent<Animation>();
        audio1 = GetComponent<AudioSource>();

    }

    void update()
    {
        Debug.Log(counter);
       
    }


    void OnTriggerEnter()
    {
        // the counter is only used to ensure that the animation will not play again 
        if (counter < 1)
        {          
            audio1.Play();        
            MonsterWindow.Play();
            counter = counter + 1;
        }
    }

 
}
