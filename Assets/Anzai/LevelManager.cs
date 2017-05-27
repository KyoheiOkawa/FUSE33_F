using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    static public int _GameLevel = 1;
    public int a = _GameLevel;

    public GameObject TextObj;
    Text _myText;

    // Use this for initialization
    void Start()
    {
        var scene = SceneManager.GetActiveScene();
        var sceneName = scene.name;

        if (sceneName == "Stage1")
        {
            _myText = TextObj.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        var scene = SceneManager.GetActiveScene();
        var sceneName = scene.name;

        if (sceneName == "Stage1")
        {
            a = _GameLevel;
            Score._LevelScore = _GameLevel;
            _myText.text = _GameLevel.ToString();//テキストの変更
        }
    }
}
