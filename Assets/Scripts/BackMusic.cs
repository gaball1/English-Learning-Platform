using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusic : MonoBehaviour {

	private static BackMusic back;
	void Awake () {
		if (back == null)
		{
			back = this;
			DontDestroyOnLoad(back);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject);
	}
}
