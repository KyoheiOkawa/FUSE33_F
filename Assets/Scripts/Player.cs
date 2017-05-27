using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public const float _MaxLife = 100;
	public float _life = 100;

	public float _damageValue = 10;//1秒あたりのダメージ量

	public float _recoveryValue = 5;

	public GameObject _hpGauge;

	private GameObject[] _enemies;

	// Use this for initialization
	void Start () {
		_enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		IsHitLight ();

		Recovery ();
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

		foreach (var enemy in _enemies) {
			var enePos = enemy.transform.position;
			Vector3 dir = enePos - ownPos;
			float length = dir.magnitude;
			dir.Normalize ();

			float range = enemy.GetComponent<Light> ().range;

			if(!Physics.Raycast(ownPos,dir,length)){
				if(length < range)
					_life -= _damageValue * Time.deltaTime;

				SetHPGaugeValue ();
			}
		}
	}

	void SetHPGaugeValue()
	{
		float uiValue = (_MaxLife - _life) / _MaxLife;
		uiValue = Mathf.Min (uiValue, _MaxLife);
		_hpGauge.GetComponent<GameUI> ().gage = uiValue;
	}
}
