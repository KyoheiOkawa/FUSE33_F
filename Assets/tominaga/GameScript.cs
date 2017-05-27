using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
	[SerializeField]
	UnityEngine.UI.Text scoreText;

	void Awake()
	{
		Score s = GameObject.FindObjectOfType<Score>();
		if(s != null)
		{
			scoreText.text = s.a.ToString();
		}
	}

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Title");
    }
}
