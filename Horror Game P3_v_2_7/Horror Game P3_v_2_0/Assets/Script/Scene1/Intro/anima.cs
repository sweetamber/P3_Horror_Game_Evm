using UnityEngine;
using System.Collections;
//using UnityEditor.Animations;

public class anima : MonoBehaviour {
    //This script is attached to "Scene 1: LevelOpeningSound"

    Animation OpenScene;
    GameObject GO_Camera;
    GameObject GO_Camera2;
    GameObject MinusPlayerMovement;

    GameObject ToBeDestroyed;

    Camera Camera;
    Camera Camera2;
    CharacterController Movement;

    // Used to time the jump from camera 2(animation) to camera 1 (Animation)
    float time = 0;
    public float timeOfCutScene = 15;
    public bool CutSceneRunning = true;

	// Use this for initialization
	void Start () {

        //Gets the gameobjects needed for the cutscene
        GO_Camera = GameObject.Find("FirstPersonCharacter");
        ToBeDestroyed = GameObject.Find("LevelOpeningSound");
        MinusPlayerMovement = GameObject.Find("FPSController");

        GO_Camera2 = GameObject.Find("Camera2");

        Camera = GO_Camera.GetComponent<Camera>();
        Camera2 = GO_Camera2.GetComponent<Camera>();

        OpenScene = GO_Camera2.GetComponent<Animation>();

        Movement = MinusPlayerMovement.GetComponent<CharacterController>();


    }
	
	// Update is called once per frame
	void Update () {
        OpenLevel();
	}

    //Checks the time since startup, and plays an animation till 15 seconds has passed, then destroy animation camera and activates player camera :) 
    void OpenLevel()
    {
        Movement.enabled = false;
        Camera.enabled = false;
        Camera2.enabled = true;        
        time += Time.deltaTime;
        if (time < timeOfCutScene && CutSceneRunning)
        {
           // Debug.Log(time);
            OpenScene.Play();
        }
        else
        {
            CutSceneRunning = false;
            Camera2.enabled = false;
            Camera.enabled = true;
            Destroy(ToBeDestroyed);
            Movement.enabled = true;
        }
    }
    
}
