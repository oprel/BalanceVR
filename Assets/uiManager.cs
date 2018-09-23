using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
	public Text scoreDisplay;

	private void Update() {
		string s = "";
		foreach (gameManager.player p in gameManager.players){
			s += 	"<color=#" + ColorUtility.ToHtmlStringRGB(p.color) + ">" +
					p.name + "</color>: " + p.score + "\n";
		}
		scoreDisplay.text = s;

	}
}
