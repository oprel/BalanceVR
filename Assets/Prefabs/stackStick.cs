using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackStick : MonoBehaviour {


	public bool absoluteParent;
	[HideInInspector] public bool partofStack;
	private stackStick parent;
	private Vector3 originalScale;
	
	private void Awake() {
		originalScale = transform.localScale;
	}

	private void OnCollisionEnter(Collision col) {
		if (partofStack) return;
		stackStick other  = col.transform.GetComponent<stackStick>();
		if (other && (other.partofStack || other.absoluteParent)){
			partofStack = true;
			parent = other;
			//transform.parent = parent.transform;
			transform.SetParent(other.transform,true);
		}
	}

	
	private void OnCollisionExit(Collision col) {
		if (!partofStack) return;
		stackStick other  = col.transform.GetComponent<stackStick>();
		if (other && other == parent){
			partofStack = false;
			parent = null;
			transform.parent=null;
			transform.localScale=originalScale;
		}
	}
}
