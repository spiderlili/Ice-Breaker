using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int maxHits; //how many times it can be hit
    public Sprite[] hitSprites;
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

        //destroy the brick after hitting it maxHits times(safeguard superball situation to never miss maxHits)
        if (timesHit >= maxHits)
        {
            Destroy(gameObject); //this = a brick, must destroy game object
        }
        else {
            LoadSprites();
        }
        //SimulateWin();
    }

    //load sprite if player damaged the block
    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    //TODO Remove this method once win detection implemented
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }
}
