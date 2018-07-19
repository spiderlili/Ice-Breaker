using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private Rigidbody2D ballRigidBody;

	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
        ballRigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        //only hold the ball to the paddle if the game hasn't started
        if (!hasStarted) {
            //lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector; //stay in relative position

            //wait for a mouse press to launch
            if (Input.GetMouseButton(0))
            {
                hasStarted = true;
                ballRigidBody.velocity = new Vector2(2f, 10f);
            }
        }

    }
}
