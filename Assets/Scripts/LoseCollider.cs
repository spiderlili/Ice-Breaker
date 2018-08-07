using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    private LevelManager levelManager; //access level manager

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision"); //physics
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //link to level manager automatically rather than with editor assignment
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        print("trigger"); 
        levelManager.LoadLevel("LoseScreen");
    }
}
