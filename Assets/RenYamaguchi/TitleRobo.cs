using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRobo : MonoBehaviour {

	void Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime);
		transform.RotateAround(Vector3.up, 1 * Time.deltaTime);
	}
}
