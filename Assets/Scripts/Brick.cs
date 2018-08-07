﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int maxHits; //how many times it can be hit
    private int timesHit;//how many times it has been hit
    private LevelManager levelManager;

    void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        SimulateWin();
    }

    //TODO Remove this method once win detection implemented
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }
}
