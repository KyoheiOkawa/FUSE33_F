using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	[SerializeField]
	Image basefilament; // ゲージ.

	[SerializeField]
	bool isFill = false; // 表示の仕方を変更する.

	[SerializeField, Range(0,1)]
	public float gage = 0; // ゲージ表示量（テスト用）.

	[SerializeField]
	Text timeText; // .

	public string time
	{
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}

			int i = 0;
			if (!int.TryParse(value, out i)) { return; }
			timeText.text = value;
		}
	}

	[SerializeField]
	Text lavelText; // .

	public string level
	{
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}

			int i = 0;
			if (!int.TryParse(value, out i)) { return; }
			lavelText.text = value;
		}
	}

	// ゲージの表示変更.
	public float updateFilament
	{
		set
		{
			if (basefilament == null) { return; }

			if (!isFill)
			{
				Color c = basefilament.color;
				c.a = value;
				basefilament.color = c;
			}
			else
			{
				basefilament.fillAmount = value;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// filament の更新　別から値を取得する場合　game を変更する.
		updateFilament = Mathf.Lerp(0, 1, gage);



	}
}
