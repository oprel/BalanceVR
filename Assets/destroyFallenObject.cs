using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFallenObject : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            
        }
        





    }
    





}
