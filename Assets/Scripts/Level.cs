using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour {
  
    //keep track of how many blocks are remaining
    [SerializeField]int breakableBlocks; //serialised for debugging
    LevelManager levelManager; //cached reference

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed() {
        breakableBlocks--;
        if (breakableBlocks <= 0) {
            levelManager.LoadNextLevel();
        }
    }
}
