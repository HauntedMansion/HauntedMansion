using UnityEngine;
using System.Collections;

public class GhoulController : MonoBehaviour {
	int health;
	public GameObject player;
	public int slowDist;
	public float moveSpeed;
	public float slowSpeed;
	public float teleportAfterShot = 7;

	// Use this for initialization
	void Start () {
		health = 200;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Destroy (this.gameObject);

		transform.LookAt (player.transform);
		if (Vector3.Distance (transform.position, player.transform.position) <= slowDist) {
			transform.position += transform.forward * slowSpeed * Time.deltaTime;
		} else {
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
	}

	public void takeDamage (int damage)
	{
		health -= damage;
	}

	public int returnHealth()
	{
		return health;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			Destroy (other.gameObject);

		if (other.tag == "Bullet") {
			transform.position -= transform.forward * teleportAfterShot;
		}
	}
}
