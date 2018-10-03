using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
	
	public static gameManager self;
	public static player currentPlayer;
	public static List<player> players = new List<player>();
	public static List<GameObject> blocks = new List<GameObject>();
	public static int currentRound;
	public static int hardScoreVR =0;
	public Color[] colors;
	public int roundAmount;
	public static bool endOfGame;

	public protoSpawner spawner;

	private static float previousPlacement;

	
	public class player
	{	
		public int i;
		public int score;
		public int hardScore;
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
		currentRound = 1;
	}

	public static void placeBlock(Vector2 pos){
		if (Time.time - previousPlacement < .5f || endOfGame)
			return;
		previousPlacement = Time.time;
		GameObject obj = self.spawner.SpawnBlock(pos);
		protoBlock block = obj.GetComponent<protoBlock>();
		block.init(currentPlayer);
		currentPlayer.placedBlocks.Add(block);
		
		int i = (currentPlayer.i+1)%players.Count;
		if (i==0) nextRound();
		currentPlayer = players[i];
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

	public static void nextRound(){
		
		foreach (player p in players){
			p.hardScore+=p.score;
		}
		players.Sort((IComparer<player>)new sort());
		for (int i = 0; i <players.Count; i++)
		{
			players[i].i=i;
		}
		hardScoreVR += blocks.Count;
		if (currentRound==self.roundAmount){
			endOfGame = true;
			blocks = new List<GameObject>();
		}else{
			currentRound++;
		}
	}

	 private class sort : IComparer<player>{
         int IComparer<player>.Compare(player A, player B) {
             return B.hardScore.CompareTo(A.hardScore);
         }
	 }

}


