using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody My_Player;
    private bool Move_Left;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        //Getting Rigibody of the player
        My_Player = GetComponent<Rigidbody>();
        //when the game first srarts the player goes to left side
        Move_Left = true;
    }

    // Update is called once per frame
    void Update()
    {
        //calling the input checker function 
        Input_checker();
        //calling gameover function
        Game_Over();
    }

    //For using the physics components 
    void FixedUpdate()
    {
        if (Game_Controller.current.Game_Start)
        {
            if (Move_Left)
            {
                //Moving the player to left by changing the velocity
                My_Player.velocity = new Vector3(-Speed, Physics.gravity.y, 0f);
            }
            else
            {
                //Moving the player to right by changing the velocity (speed at z axis)
                My_Player.velocity = new Vector3(0f, Physics.gravity.y, Speed);
            }
        }
    }

    //checking to see if the game is over
    void Game_Over()
    {
        if (Game_Controller.current.Game_Start)
        {
            //if the position of player on Y axis is less that -3 
            //the the game is over 
            if(transform.position.y < -8)
            {
                Debug.Log("Game over");
                Game_Controller.current.Game_Start = false;
                Destroy(gameObject);
            }
        }
    }

    //checking the input of mouse and keyboard
    void Input_checker()
    {
        //getting left mouse click(0) and space button bu input 
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            /*
             * Preventing the game from starting instantly
             * the game start only when you press space or click.
             */
            if (!Game_Controller.current.Game_Start)
            {
                Game_Controller.current.Game_Start = true;
                //activate platform generator
                Game_Controller.current.Activate_Platform_Generator();
            }
        }
        //when the game is playing
        if (Game_Controller.current.Game_Start)
        {
            //changing direction to right and left based on mouse click or space button press
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                //changing the bool value, for changing the direction
                Move_Left = !Move_Left;
            }
        }
    }
}


/*
 * References:
 * https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html
 * https://docs.unity3d.com/ScriptReference/Input.html
 * https://stackoverflow.com/questions/43323941/inconsistent-line-endings-visual-studio-community-2017
 */
