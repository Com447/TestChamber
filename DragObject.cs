using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject player;
    public float dragSpeed = 5f;
    public float distanceThreshold = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance > distanceThreshold)
        {
            transform.position += (Vector3)(player.transform.position - transform.position) * Time.deltaTime * dragSpeed;
        }
    }
}
