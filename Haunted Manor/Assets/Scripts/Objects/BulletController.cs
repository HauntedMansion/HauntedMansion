using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<GhoulController> ().takeDamage (10);
		}
		Destroy (this.gameObject);
	}
}
