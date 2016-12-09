using UnityEngine;
using System.Collections;

public class DONTDESTROY : MonoBehaviour {

    void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);


    }
}
