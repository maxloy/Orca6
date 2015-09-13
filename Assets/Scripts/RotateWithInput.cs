using UnityEngine;
using System.Collections;

public class RotateWithInput : MonoBehaviour
{
	public float RotationSpeed = 1;

	void Update()
	{
		Vector3 r = transform.rotation.eulerAngles;
		r.z -= Input.GetAxis("Horizontal") * RotationSpeed;
		r.x += Input.GetAxis("Vertical") * RotationSpeed;
		transform.rotation = Quaternion.Euler(r);
	}
}
