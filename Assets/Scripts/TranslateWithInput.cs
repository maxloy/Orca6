using UnityEngine;
using System.Collections;

public class TranslateWithInput : MonoBehaviour
{

	public float MoveSpeed = 1;

	void Update()
	{
		transform.position += new Vector3
			(
				Input.GetAxis("Right_X_Axis") * MoveSpeed,
				0,
				Input.GetAxis("Right_Y_Axis") * MoveSpeed
			);
		transform.position += new Vector3
			(
				Input.GetAxis("Mouse X") * MoveSpeed,
				0,
				Input.GetAxis("Mouse Y") * MoveSpeed
			);
	}
}
