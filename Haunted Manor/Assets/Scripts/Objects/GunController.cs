using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject bulletEmitter;

	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject bullet;

	//Enter the Speed of the Bullet from the Component Inspector.
	public float bulletForwardForce;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//The Bullet instantiation happens here.
			GameObject tempBulletHandler;
			tempBulletHandler = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//tempBulletHandler.transform.Rotate(Vector3.left * 90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody tempRB;
			tempRB = tempBulletHandler.GetComponent<Rigidbody>();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			tempRB.AddForce(transform.up * bulletForwardForce);

			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(tempBulletHandler, 3.0f);
		}
	}
}