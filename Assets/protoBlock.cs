using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protoBlock : MonoBehaviour {
	private bool end;
	private stackStick stackStick;
	public int points = 0;
	public LayerMask pointMask;
	public MeshRenderer renderer;
	private gameManager.player player;

	private void Awake() {
		//transform.rotation = Random.rotation;
		stackStick = GetComponent<stackStick>();
		gameManager.blocks.Add(gameObject);
	}

	private void Update() {
		points=0;
		if (!end && transform.position.y<-.2f){
			end=true;
			gameManager.blocks.Remove(gameObject);
			if (player != null) player.placedBlocks.Remove(this);
			Destroy(gameObject,Random.Range(.5f,3f));
		}
		
		if (stackStick.partofStack && !gameManager.endOfGame){
			Transform parent = stackStick.parent.transform;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, parent.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, pointMask)){
				Debug.DrawRay(transform.position, parent.TransformDirection(-Vector3.up) * Mathf.Infinity, Color.yellow);
				pointZone pz = hit.transform.GetComponent<pointZone>();
				if (pz) points = pz.points;
			}

		}
	}

	public void init(gameManager.player p){
		player = p;
		renderer.material = new Material(renderer.material);
		renderer.material.color = p.color;
	}
	
}
