using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float TotatlGameUnits = 16;

    void Start () {
		
	}
	
	void Update () {
        //map input to mouse position
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * TotatlGameUnits;
        print(mousePosInBlocks);
        
        //constrain x at the left hand of the play space, keep y pos
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        
        //instance of the current script component
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, -7.0f, 7.0f);
        this.transform.position = paddlePos;

	}
}
