using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    //state
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

    //cached component references
    AudioSource myAudioSource;

    //config params
    private Paddle paddle;
    private Rigidbody2D ballRigidBody;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

	void Start () {
        //link to prefab
        paddle = GameObject.FindObjectOfType<Paddle>(); //Generics filter
        paddleToBallVector = this.transform.position - paddle.transform.position;
        ballRigidBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();//only finding it once for efficiency
	}

    private void LaunchOnMouseClick()
    {
        //wait for a mouse press to launch
        if (Input.GetMouseButton(0))
        {
            hasStarted = true;
            ballRigidBody.velocity = new Vector2(2f, 10f);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        //transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            //play randomised trigger sounds each time there is a collision
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            //play one shot and makes sure it plays the whole way through even if other things are playing on top of it
            myAudioSource.PlayOneShot(clip); //prevent SE from playing from the first collision before the game starts
        }
    }

    void Update () {
        //only hold the ball to the paddle if the game hasn't started
        if (!hasStarted) {
            //lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector; //stay in relative position
            LaunchOnMouseClick();
        }

    }
}
