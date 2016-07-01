using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelLoaders : MonoBehaviour {

    public void LoadLevel(string levelName)
    {
        Debug.Log("Loading Level : " + levelName);

        SceneManager.LoadScene(levelName);
    }



    public void QuitApp()
    {
        Application.Quit();

    }
}
