using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public LevelManager levelManager; //access level manager


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision"); //physics
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger"); 
        levelManager.LoadLevel("WinScreen");
    }
}
