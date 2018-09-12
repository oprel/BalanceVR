using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protoSpawner : MonoBehaviour {

	public float radius = 3;
	public float frequency = 2;
	public GameObject[] blocks;
	private float timer = 0;

	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer>frequency){
			SpawnBlock();
			timer=0;
		}
	}

	public void SpawnBlock(){
		Vector3 pos = Random.insideUnitSphere*radius;
		pos.y=0;
		GameObject b = Instantiate(blocks[Random.Range(0,blocks.Length)],transform);
		b.transform.position += pos;
	}

	private void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position,radius);
	}
}
