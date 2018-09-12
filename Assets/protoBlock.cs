using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protoBlock : MonoBehaviour {
	private bool end;
	void Start () {
		transform.rotation = Random.rotation;
	}

	private void Update() {
		if (!end && transform.position.y<.2f){
			end=true;
			Destroy(gameObject,3);
		}
	}
	
}
