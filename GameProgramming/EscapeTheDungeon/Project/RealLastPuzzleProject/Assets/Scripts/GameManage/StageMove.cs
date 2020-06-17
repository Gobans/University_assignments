using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMove : MonoBehaviour
{
    // Start is called before the first frame update
    public void MoveNext()
    {
        Scene scene = SceneManager.GetActiveScene();
        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }
}
