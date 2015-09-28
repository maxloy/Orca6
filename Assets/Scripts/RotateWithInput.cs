using UnityEngine;
using System.Collections;

public class RotateWithInput : MonoBehaviour
{

	public Transform RotateSource;

	public float RotationSpeed = 1;

	public Space space = Space.World;

	public bool X = true;
	public bool Y = true;

	public Collider ControlArea = null;

	Vector3 horizontalAngle;
	Vector3 verticalAngle;

	void Start()
	{
		if(RotateSource == null)
			RotateSource = transform;

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
			transform.RotateAround(RotateSource.position, horizontalAngle, Input.GetAxis("Horizontal") * -RotationSpeed);
		if(Y)
			transform.RotateAround(RotateSource.position, verticalAngle, Input.GetAxis("Vertical") * RotationSpeed);
	}
}
