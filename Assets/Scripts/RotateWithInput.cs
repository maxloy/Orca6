using UnityEngine;
using System.Collections;

public class RotateWithInput : MonoBehaviour
{
	public float RotationSpeed = 1;

	void Update()
	{
		transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * RotationSpeed);
		transform.Rotate(Vector3.right, Input.GetAxis("Vertical") * RotationSpeed);
	}
}
