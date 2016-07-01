using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MakeLevels : MonoBehaviour {

    public int numberOfLevels = 10;
    public Button menuButton;

	// Use this for initialization
	void Start () {

        LevelMaker();
	
	}
	


    public void LevelMaker()
    {

        for (int i = 0; i < numberOfLevels; i++)
        {
            float xPosition = (i * -35);
            string  btnName = "btnLevel" + (i + 1);
            string btnLabel = "Level " + (i + 1);
            string levelNumber = (i + 1).ToString();
            string sceneName =  "Scene" + levelNumber;

            MakeMenuButton(btnName, btnLabel, sceneName, xPosition);
        }



        float xPositionQuit = (numberOfLevels * -35);
        string btnNameQuit = "btnQuit";
        string btnLabelQuit = "Quit";
        string sceneNameQuit = "gameOver";

        MakeMenuButton(btnNameQuit, btnLabelQuit, sceneNameQuit, xPositionQuit);



    }



    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);

    }


    public void MakeMenuButton(string buttonName, string buttonLabel, string sceneName,float xPosition)
    {

        Button btn = Instantiate<Button>(menuButton);
        btn.transform.SetParent(transform);
        btn.GetComponent<RectTransform>().localPosition = new Vector3(0, xPosition, 0);
        btn.gameObject.SetActive(true);
        btn.name = buttonName ;
        btn.transform.FindChild("Text").GetComponent<Text>().text = buttonLabel;        
        btn.onClick.AddListener(() => LoadLevel(sceneName));

    }
}
