using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorTransform : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            transform.position = target.position + target.rotation*offset;
            transform.rotation = target.rotation;
        }
      
	}
}
