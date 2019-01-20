using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    private Transform Player_Position;
    private Vector3 Old_Position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        //Getting the position of the player
        Player_Position = GameObject.FindGameObjectWithTag("Player").transform;
        //setting old position to player position
        Old_Position = Player_Position.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Checking to see if we have the position of the ball 
        if (Player_Position)
        {
            //getting current position of the player
            Vector3 New_Position = Player_Position.position;
            //Calculating the delta, which is the old position minus new position
            Vector3 delta = Old_Position - New_Position;
            //setting delta Y to zero
            //Because we don’t want to move the camera on Y axis in the game
            //Only X and Z changes
            delta.y = 0f;
            //Current position of camera = camera position - delta
            transform.position = transform.position - delta;
            //Updating camera position since the camera has moved
            Old_Position = New_Position;
        }
    }

}


/*
 * References:
 * https://docs.unity3d.com/ScriptReference/Camera.html
 * https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera
 * https://www.youtube.com/watch?v=o8YjVB5MYf8
 */
