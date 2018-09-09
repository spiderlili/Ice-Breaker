using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1.0f;
    
	// Use this for initialization
	void Start () {
		
	}

    //speed needs to be known for every single frame
    void Update () {
        Time.timeScale = gameSpeed;
	}
}
