using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private Vector3 respawnPoint;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "NextLevel")
        {
            transform.position = respawnPoint;
        }
        else if (col.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
