using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

	public float Speed = 50;

	void OnTriggerEnter(Collider other)
	{
		var body = other.GetComponent<Rigidbody>();
		if (body != null && body.isKinematic == false)
		{
			body.velocity = transform.up * Speed;
			//body.AddForce(transform.up * Force);
		}
	}
}
