using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public GameObject nextScreen;

    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void LateUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = transform.position;

        if (playerPosition.x > cameraPosition.x + screenWidth / 2)
        {
            // Player has reached the right edge of the screen, move camera to the right
            transform.position = new Vector3(transform.position.x + screenWidth, transform.position.y, transform.position.z);

            // Move camera to the next screen
            if (nextScreen != null)
            {
                transform.position = nextScreen.transform.position;
            }
        }
        else if (playerPosition.x < cameraPosition.x - screenWidth / 2)
        {
            // Player has reached the left edge of the screen, move camera to the left
            transform.position = new Vector3(transform.position.x - screenWidth, transform.position.y, transform.position.z);

            // Move camera to the previous screen
            if (nextScreen != null)
            {
                transform.position = nextScreen.transform.position;
            }
        }

        if (playerPosition.y > cameraPosition.y + screenHeight / 2)
        {
            // Player has reached the top edge of the screen, move camera up
            transform.position = new Vector3(transform.position.x, transform.position.y + screenHeight, transform.position.z);

            // Move camera to the next screen
            if (nextScreen != null)
            {
                transform.position = nextScreen.transform.position;
            }
        }
        else if (playerPosition.y < cameraPosition.y - screenHeight / 2)
        {
            // Player has reached the bottom edge of the screen, move camera down
            transform.position = new Vector3(transform.position.x, transform.position.y - screenHeight, transform.position.z);

            // Move camera to the previous screen
            if (nextScreen != null)
            {
                transform.position = nextScreen.transform.position;
            }
        }
    }
}
