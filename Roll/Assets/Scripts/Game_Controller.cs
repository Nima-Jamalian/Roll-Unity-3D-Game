using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //Color Changing 
    [SerializeField] private Material platformMat;
    [SerializeField] private Light dayLight;
    private Camera mainCamera;
    private bool camColorLerp;
    private Color cameraColor;
    private Color[] platformColorDay;
    private Color platformColorNight;
    private int platformColorIndex;
    private Color platformTrueColor;
    private float timer;
    [SerializeField] private float timerInterval = 10f;
    private float camLerpTimer;
    private float camLeprInterval = 1f;
    private int direction = 1;

    void Awake()
    {
        GameManeger();
        //getting gold audio source
        audioSource = GetComponent<AudioSource>();
        //fixed start position
        Current_Platform_Position = new Vector3(-2, 0, 2);

        mainCamera = Camera.main;
        cameraColor = mainCamera.backgroundColor;
        platformTrueColor = platformMat.color;
        platformColorIndex = 0;
        platformColorDay = new Color[3];
        platformColorDay[0] = new Color(10 / 256f, 139 / 265f, 203 / 256f);
        platformColorDay[1] = new Color(10 / 256f, 200 / 265f, 20 / 256f);
        platformColorDay[2] = new Color(220 / 256f, 170 / 265f, 45 / 256f);
        platformColorNight = new Color(0, 8 / 256f, 11 / 256f);
        platformMat.color = platformColorDay[0];
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
        platformMat.color = platformTrueColor;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("GameScene");
        }*/
        CheckLerpTimer();
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

    void CheckLerpTimer()
    {
        timer += Time.deltaTime;

        if (timer > timerInterval)
        {
            timer -= timerInterval;
            camColorLerp = true;
            camLerpTimer = 0f;
        }

        if (camColorLerp)
        {
            camLerpTimer += Time.deltaTime;
            float percent = camLerpTimer / camLeprInterval;

            if(direction == 1)
            {
                mainCamera.backgroundColor = Color.Lerp(cameraColor, Color.black, percent);
                platformMat.color = Color.Lerp(platformColorDay[platformColorIndex], platformColorNight, percent);
                dayLight.intensity = 1f - percent;
            } else
            {
                mainCamera.backgroundColor = Color.Lerp(Color.black, cameraColor, percent);
                platformMat.color = Color.Lerp(platformColorNight, platformColorDay[platformColorIndex], percent);
                dayLight.intensity = percent;
            }
            if(percent > 0.98f)
            {
                camLerpTimer = 1f;
                direction *= -1;
                camColorLerp = false;
                if(direction == -1)
                {
                    platformColorIndex = Random.Range(0, platformColorDay.Length);
                }
            }
        }
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

