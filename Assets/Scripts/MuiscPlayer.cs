using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuiscPlayer : MonoBehaviour {
    static MuiscPlayer instance = null; //at the start init scene there will be no defined thing called instance

    void Awake()
    {
        if (instance != null)
        {
            //if any musicplayer instance exists, destroy itself
            Destroy(gameObject);
        }
        else
        {
            instance = this; //claim the instance
            GameObject.DontDestroyOnLoad(gameObject);
        }

    }
    // Use this for initialization
    void Start () {
        Debug.Log("Music player start " + GetInstanceID());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
