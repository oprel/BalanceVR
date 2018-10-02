using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
	public Text scoreDisplay;
	public Text currentPlayer;
	public Text roundDisplay;
	public TextMesh blockCount;

	private void Update() {
		string s = "";
		foreach (gameManager.player p in gameManager.players){
			s += 	"<color=#" + ColorUtility.ToHtmlStringRGB(p.color) + ">" +
					p.name + "</color>: " + p.hardScore;
			if (p.score>0) s+= " (+" + p.score + ")";
			s+= "\n";
		}
		scoreDisplay.text = s;

		currentPlayer.text = gameManager.currentPlayer.name + "'s turn";
		currentPlayer.color = gameManager.currentPlayer.color;
		blockCount.text = gameManager.blocks.Count.ToString();
		roundDisplay.text = "ROUND " + gameManager.currentRound.ToString() + "/" + gameManager.self.roundAmount.ToString();

	}
}
