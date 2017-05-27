using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static int _LevelScore = 0;
    public int a = 0;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        a = _LevelScore;
	}
}
