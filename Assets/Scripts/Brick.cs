using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    public int maxHits; //how many times it can be hit
    public Sprite[] hitSprites;
    private int timesHit;//how many times it has been hit
    private LevelManager levelManager;
    private GameStatus gameStatus;
    Level level; //cached reference

    void Start () {
        timesHit = 0;
        gameStatus = GameObject.FindObjectOfType<GameStatus>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        level = FindObjectOfType<Level>(); //keep track of breakable blocks
        level.CountBreakableBlocks(); //each block to add itself to the total - load the next level when it reaches 0
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position); //play 3D sound at camera position and destroy itself
  

        //destroy the brick after hitting it maxHits times(safeguard superball situation to never miss maxHits)
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else {
            LoadSprites();
        }
        //SimulateWin();
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        Destroy(gameObject); //this = a brick, must destroy game object
        level.BlockDestroyed();
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
