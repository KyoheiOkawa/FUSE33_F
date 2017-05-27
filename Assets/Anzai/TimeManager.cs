using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public float _limitTime = 10.0f;

    public GameObject _TimeText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (_TimeText != null)
        {
            var timeText = _TimeText.GetComponent<Text>();
            var temp = (int)_limitTime;
            timeText.text = temp.ToString();//テキストの変更

            _limitTime -= Time.deltaTime;

            if (_limitTime <= 0.0f)
            {
                _limitTime = 0.0f;
                SceneManager.LoadScene("Result");
                Debug.Log("ToResult");
            }
        }
	}
}
