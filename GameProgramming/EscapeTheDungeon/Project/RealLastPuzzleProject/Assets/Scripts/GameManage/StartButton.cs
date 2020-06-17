using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            int curScene = scene.buildIndex;
            int nextScene = curScene + 1;
            SceneManager.LoadScene(nextScene);
        }
    }
}
