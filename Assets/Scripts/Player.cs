using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public const float _MaxLife = 100;
	public float _life = 100;

	public float _damageValue = 10;//1秒あたりのダメージ量

	public float _recoveryValue = 5;

	public GameObject _hpGauge;

	public AudioClip _damageSound;

	private GameObject[] _enemies;

	public AudioSource _audio;

	private bool _isSetDmageClip = false;

	// Use this for initialization
	void Start () {
		_enemies = GameObject.FindGameObjectsWithTag ("Enemy");

        LevelManager._GameLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();

        IsHitLight ();

		Recovery ();

		if (_life <= 0)
			SceneManager.LoadScene ("result");
	}

	void Recovery()
	{
		if (_life < _MaxLife)
			_life += _recoveryValue * Time.deltaTime;

		SetHPGaugeValue ();
	}

	void IsHitLight()
	{
		var ownPos = transform.position;

        bool isOffSE = true;

		foreach (var enemy in _enemies) {
			var enePos = enemy.transform.position;
			Vector3 dir = enePos - ownPos;
			float length = dir.magnitude;
			dir.Normalize ();

			float range = enemy.GetComponent<Light> ().range;

			if (!Physics.Raycast (ownPos, dir, length)) {
				if (length < range) {
					_life -= _damageValue * Time.deltaTime;

					if (!_isSetDmageClip) {
						_isSetDmageClip = true;
						_audio.clip = _damageSound;
						_audio.loop = true;
						_audio.Play ();
					}

                    isOffSE = false;
				}

				SetHPGaugeValue ();
			}
		}
        if (isOffSE)
        {
            _isSetDmageClip = false;
            _audio.Stop();
        }
	}

	void SetHPGaugeValue()
	{
		float uiValue = (_MaxLife - _life) / _MaxLife;
		uiValue = Mathf.Min (uiValue, _MaxLife);
		_hpGauge.GetComponent<GameUI> ().gage = uiValue;
	}
}
