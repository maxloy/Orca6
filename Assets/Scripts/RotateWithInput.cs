using UnityEngine;
using System.Collections;

public class RotateWithInput : MonoBehaviour
{
	public float RotationSpeed = 1;

	public Space space = Space.World;

	public bool X = true;
	public bool Y = true;

	public Collider ControlArea = null;

	Vector3 horizontalAngle;
	Vector3 verticalAngle;

	void Start()
	{
		if(space == Space.World)
		{
			horizontalAngle = Vector3.forward;
			verticalAngle = Vector3.right;
		}
		else
		{
			horizontalAngle = transform.forward;
			verticalAngle = transform.right;
		}
	}

	void Update()
	{
		if(X)
			transform.Rotate(horizontalAngle, Input.GetAxis("Horizontal") * -RotationSpeed, Space.World);
		if(Y)
			transform.Rotate(verticalAngle, Input.GetAxis("Vertical") * RotationSpeed, Space.World);
	}
}
