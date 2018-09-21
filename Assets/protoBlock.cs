using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protoBlock : MonoBehaviour {
	private bool end;
	private stackStick stackStick;
	public int points = 0;
	public LayerMask pointMask;

	private void Awake() {
		//transform.rotation = Random.rotation;
		stackStick = GetComponent<stackStick>();
	}

	private void Update() {
		if (!end && transform.position.y<.2f){
			end=true;
			Destroy(gameObject,3);
		}

		if (stackStick.partofStack){
			Transform parent = stackStick.parent.transform;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, parent.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, pointMask)){
				Debug.DrawRay(transform.position, parent.TransformDirection(-Vector3.up) * Mathf.Infinity, Color.yellow);
				pointZone pz = hit.transform.GetComponent<pointZone>();
				if (pz) points = pz.points;
			}

		}
	}
	
}
