using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFocus : MonoBehaviour {

	public Transform focusPoint;
	void Update () {
		transform.LookAt(focusPoint);
	}
}
