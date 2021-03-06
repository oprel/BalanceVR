﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackStick : MonoBehaviour {


	public bool absoluteParent;
	private Vector3 originalScale;
	public bool partofStack;
	public stackStick parent;
	
	
	private void Awake() {
		originalScale = transform.localScale;
	}

	private void Update() {
		if (partofStack){
			if (transform.position.y<parent.transform.position.y-.5f){
				stackRemove(parent);
			}
		}
	}

	private void OnCollisionEnter(Collision other) {
		if (!partofStack)
			stackAdd(getOther(other));
        //Debug.Log(other.gameObject.name);
	}

	private void OnCollisionStay(Collision other) {
		if (!partofStack)
			stackAdd(getOther(other));
	}

	private void OnCollisionExit(Collision other) {
		if (partofStack)
			stackRemove(getOther(other));
		
	}

	private void stackAdd(stackStick other){
		if (other && (other.partofStack || other.absoluteParent)){
			partofStack = true;
			parent = other;
			transform.SetParent(other.transform);
		}
	}

	private void stackRemove(stackStick other){
		if (other && other == parent){
			partofStack = false;
			parent = null;
			transform.parent=null;
			transform.localScale=originalScale;
		}
	}

	private stackStick getOther(Collision col){
        Transform p = col.transform.parent;
        if (p)
        {

            return p.GetComponent<stackStick>(); ;
        }
   
        return null;
		
	}
}
