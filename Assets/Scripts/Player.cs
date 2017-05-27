using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public const float _MaxLife = 100;
	public float _life = 100;

	private GameObject[] _enemies;

	// Use this for initialization
	void Start () {
		_enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		IsHitLight ();
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
					_life -= Time.deltaTime;
			}
		}
	}
}
