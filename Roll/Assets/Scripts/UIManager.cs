using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableStartCanvas()
    {
        startCanvas.SetActive(false);
        Game_Controller.current.Game_Start = true;
        DisplayGameCanvas(true);
        Game_Controller.current.Activate_Platform_Generator();
    }

    public void DisplayGameCanvas(bool show)
    {
        gameCanvas.SetActive(show);
    }

    public void DisplayScore(int userScore)
    {
        scoreText.text = "Score: " + userScore;
    }

    public void DisplayGameOver(bool show, int score)
    {
        DisplayGameCanvas(false);
        gameOverCanvas.SetActive(show);
        gameOverText.text = "Score: " + score; 
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenNimaWebsite()
    {
        Application.OpenURL("https://nima-jamalian.github.io/CV/");
        Debug.Log("clicked");
    }
}
