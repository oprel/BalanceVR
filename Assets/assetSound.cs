using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetSound : MonoBehaviour {

    private AudioSource AS;
    public AudioClip blockSound;

    void Start() {
        AS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col) {
       
                AS.PlayOneShot(blockSound);   
        
    }
}
 