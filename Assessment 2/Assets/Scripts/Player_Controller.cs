using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public static Player_Controller current;
    //for checking game start state
    public bool Game_Start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        GameManeger();
    }

    void OnDisable()
    {
        //object gets disable when gameobject gets destroyed
        current = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameManeger()
    {
        if (current == null)
        {
            //Player_Controller, making only one gameobject
            current = this;
        }
    }
}


/*
 * References:
 * http://wiki.unity3d.com/index.php/Singleton
 * https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
 * https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern
 */
