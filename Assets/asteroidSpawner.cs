using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour {

	public float outerRadius;
	public float innerRadius;
	public float frequency;
	public GameObject asteroid;
	public Transform target;
    public float speedMax;


	private float timer;

	private void Update() {
		if (frequency>0){
			timer += Time.deltaTime;
			if (timer>frequency){
				spawnAsteroid();
				timer=0;
			}
		}
	}

	public void spawnAsteroid(){
		Vector3 pos;
		do{
			pos = Random.insideUnitSphere * outerRadius;
			pos.y = Mathf.Abs(pos.y);
		}while(pos.magnitude<innerRadius);
		GameObject o = Instantiate(asteroid, transform);
		o.transform.position = pos + transform.position;
		o.transform.LookAt(target);
		float speed = Random.Range(1,speedMax);
		o.GetComponent<Rigidbody>().velocity = o.transform.forward * speed;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawWireSphere(transform.position,outerRadius);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,innerRadius);

	}
}
