using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Score scoreScript;
    
    private Vector3 respawnPoint;
    
    public GameObject level1,level2,level3,level4,level5,level6,level7,level8;
    
    public int level = 1;

    public bool Resume = false;
    
    
    
    
    
    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        respawnPoint = transform.position;
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
        level7.SetActive(false);
        level8.SetActive(false);
    }

    void Update()
    {
        if (level == 1)
        {
            level1.SetActive(true);
        }
        else if (level == 2)
        {
            level2.SetActive(true);
            level1.SetActive(false);
        }
        else if (level == 3)
        {
            level3.SetActive(true);
            level2.SetActive(false);
        }
        else if (level == 4)
        {
            level4.SetActive(true);
            level3.SetActive(false);
        }
        else if (level == 5)
        {
            level5.SetActive(true);
            level4.SetActive(false);
        }
        else if (level == 6)
        {
            level6.SetActive(true);
            level5.SetActive(false);
        }
        else if (level == 7)
        {
            level7.SetActive(true);
            level6.SetActive(false);
        }
        else if (level == 8)
        {
            level8.SetActive(true);
            level7.SetActive(false);
            scoreScript.ShowDead();
        }
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "KillPlayer")
        {
            transform.position = respawnPoint;
            scoreScript.AddDead();
        }
        else if (col.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        else if (col.tag == "NextLevel")
        {
            transform.position = respawnPoint;
            
            level += 1;
        }
        else if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            scoreScript.AddPoint();
        }
    }
    
}
