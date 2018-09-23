using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
	
	public static gameManager self;
	public static player currentPlayer;
	public static List<player> players = new List<player>();
	public Color[] colors;
	public protoSpawner spawner;
	
	public class player
	{	
		public int i;
		public int score;
		public string name;
		public Color color;
		public List<protoBlock> placedBlocks;
	}

	private void Awake() {
		self = this;
		startGame(4);
	}
	public static void startGame(int playerCount){
		if (playerCount<2) return;
		players.Clear();
		
		for (int i = 0; i <playerCount; i++)
		{
			player p = new player();
			p.color=self.colors[i%self.colors.Length];
			p.name = "Player " + (i+1).ToString();
			p.placedBlocks = new List<protoBlock>();
			p.i = i;
			players.Add(p);
		}
		currentPlayer = players[0];
	}

	public static void placeBlock(Vector2 pos){
		GameObject obj = self.spawner.SpawnBlock(pos);
		protoBlock block = obj.GetComponent<protoBlock>();
		block.setColor(currentPlayer.color);
		currentPlayer.placedBlocks.Add(block);
		currentPlayer = players[(currentPlayer.i+1)%players.Count];
	}

	private void Update() {
		//update score
		foreach (player p in players){
			p.score = 0;
			foreach(protoBlock b in p.placedBlocks){
				p.score += b.points;
			}
		}
	}
}
