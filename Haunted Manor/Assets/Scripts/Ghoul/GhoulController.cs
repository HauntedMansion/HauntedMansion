using UnityEngine;
using System.Collections;

public class GhoulController : MonoBehaviour {
	int health;
	public GameObject player;
	public int slowDist;
	public float moveSpeed;
	public float slowSpeed;
	public float teleportAfterShot = 10;

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
			randomTeleport ();
			randomTeleport ();
			randomTeleport ();
		}
	}

	void randomTeleport()
	{
		float direction = Random.value;

		if (direction <= 0.25f)
			transform.position -= transform.forward * teleportAfterShot;
		else if (direction > 0.25f && direction <= 0.5f)
			transform.position = transform.forward * teleportAfterShot;
		else if (direction > 0.5f && direction <= 0.75f)
			transform.position = transform.right * teleportAfterShot;
		else if (direction > 0.75f && direction <= 1f)
			transform.position -= transform.right * teleportAfterShot;

	}
}
