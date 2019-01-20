using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public static Game_Controller current;
    //for checking game start state
    public bool Game_Start;

    [SerializeField]
    private GameObject platform;
    //for storing position of current new platform
    private Vector3 Current_Platform_Position;
    private AudioSource audioSource;

    void Awake()
    {
        GameManeger();
        //getting gold audio source
        audioSource = GetComponent<AudioSource>();
        //fixed start position
        Current_Platform_Position = new Vector3(-2, 0, 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Platform_generator();
        }
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

    //creating new platforms
    void Platform_generator()
    {
        Vector3 new_Platform_Position = Current_Platform_Position;
        //randomising the platform position
        int random = Random.Range(0, 100);
        //if random < 50 -> moving on X axsis by one
        if(random < 50)
        {
            new_Platform_Position.x -= 1f;
        }
        else//moving on z axsis by one
        {
            new_Platform_Position.z += 1f;
        }
        //updating the platform postion
        Current_Platform_Position = new_Platform_Position;
        Instantiate(platform, Current_Platform_Position, Quaternion.identity);
    }

    public void Activate_Platform_Generator()
    {
        StartCoroutine(Spwan_New_Platforms());
    }

    public void Play_Gold_Collection_Sound()
    {
        audioSource.Play();
    }
    //Spawning new platforms
    IEnumerator Spwan_New_Platforms()
    {
        yield return new WaitForSeconds(0.3f);
        Platform_generator();

        //if the game is running spawn new platforms
        if (Game_Start)
        {
            StartCoroutine(Spwan_New_Platforms());
        }
    }
}


/*
 * References:
 * http://wiki.unity3d.com/index.php/Singleton
 * https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager
 * https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern
 * https://unity3d.com/learn/tutorials/topics/scripting/coroutines
 * https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
 * https://www.youtube.com/watch?v=iol76dK4znA
 * https://www.udemy.com/unity-game-development-make-professional-3d-games/learn/v4/t/lecture/6707974?start=0
 * https://www.youtube.com/watch?v=7jdL5538bEo&list=PLLH3mUGkfFCXps_IYvtPcE9vcvqmGMpRK
 */
