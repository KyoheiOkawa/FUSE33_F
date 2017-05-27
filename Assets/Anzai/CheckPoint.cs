using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public AudioClip audioClip;
    private AudioSource audioSource;
    public GameObject[] _respawns;
    private int _randNum = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //音だし
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();

            //レベル上げる
            LevelManager._GameLevel++;

            var Trans = this.gameObject.GetComponent<Transform>();

            _respawns = GameObject.FindGameObjectsWithTag("Respawn");

            int tempNum = _randNum;
            while(true)
            {
                _randNum = Random.Range(0, _respawns.Length);
                if (tempNum != _randNum)
                    break;
            } 
             
            Trans.position = _respawns[_randNum].GetComponent<Transform>().position;
        }
    }
}
