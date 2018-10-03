using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
	public Text scoreDisplay;
	public Text currentPlayer;
	public Text roundDisplay;
	public Text blockCount;
	public Text endOfGame;
	public TextMesh blockCountVR;
	public TextMesh roundDisplayVR;

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
		string b = gameManager.hardScoreVR.ToString();
		if (gameManager.blocks.Count>0) b+= "(+" + gameManager.blocks.Count.ToString() + ")";
		blockCount.text = "VR SCORE: " + b;
		blockCountVR.text=b;
		string round = "ROUND " + gameManager.currentRound.ToString() + "/" + gameManager.self.roundAmount.ToString();
		roundDisplay.text = round;
		roundDisplayVR.text = round;

		if (gameManager.endOfGame){
			endOfGame.enabled = true;
			endOfGame.text = gameManager.players[0].name+ " wins!";
			endOfGame.color = gameManager.players[0].color;
		}

	}
}
