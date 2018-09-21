using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointLabel : MonoBehaviour {
	private protoBlock protoBlock;
	private TextMesh textMesh;

	private void Awake() {
		protoBlock = gameObject.GetComponentInParent(typeof(protoBlock)) as protoBlock;
		textMesh = GetComponent<TextMesh>();
	}
	// Update is called once per frame
	void Update () {
		textMesh.text = protoBlock.points.ToString();
	}
}
