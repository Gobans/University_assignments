using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;					//Allows us to use UI

public class GameManager : MonoBehaviour
{
    private string sceneName;
    public static GameManager instance = null;
    private GameObject gameOverImage;                          //Image to block out level as levels are being set up, background for levelText.
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance = this;
        gameOverImage = GameObject.Find("GameOverImage");
        gameOverImage.SetActive(false);

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { 
            sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    public void GameOver()
    {
        gameOverImage.SetActive(true);
    }

    public void Overimage()
    {

    }
}
