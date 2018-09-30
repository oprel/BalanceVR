using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {

	private ParticleSystem particleSystem;
	private SphereCollider sphereCollider;
	private Coroutine exploding;


	private void Awake() {
		particleSystem = GetComponent<ParticleSystem>();
		sphereCollider = GetComponent<SphereCollider>();
		
	}
	
	private void OnCollisionEnter(Collision other) {
		if (exploding == null) exploding = StartCoroutine(explode());
	}


	IEnumerator explode(){
		particleSystem.Play();
		sphereCollider.radius*=4;
		yield return null;
		sphereCollider.radius/=4;
		exploding = null;
		Destroy(gameObject,Random.Range(2,5));
		
	}
}
