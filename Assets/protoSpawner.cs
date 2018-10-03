using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protoSpawner : MonoBehaviour {

	public static protoSpawner self;
	public float radius = 3;
	public float frequency = 2;
	public GameObject[] blockPrefabs;
	public Transform earth;
	public float height;


	private float timer = 0;


	private void Awake() {
		self = this;

	}
	void Update () {
		if (earth){
			Vector3 pos = earth.position;
			pos.y+=height;
			transform.position =  pos;
            Quaternion rot = transform.rotation;
            rot.y = earth.transform.rotation.y;
            transform.rotation = rot;

		}
		if (frequency>0){
			timer += Time.deltaTime;
			if (timer>frequency){
				SpawnBlock(Random.insideUnitCircle);
				timer=0;
			}
		}
		
	}

	public GameObject SpawnBlock(Vector2 offset){
		offset*=radius;
		Vector3 pos = new Vector3(offset.x, 0, offset.y);
		GameObject b = Instantiate(blockPrefabs[Random.Range(0,blockPrefabs.Length)],transform);
		b.transform.position += pos;
		return b;
	}

	private void OnDrawGizmos() {
		UnityEditor.Handles.color = Color.red;
		UnityEditor.Handles.DrawWireDisc(transform.position , transform.up, radius);
	}
}
