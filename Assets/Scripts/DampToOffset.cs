using UnityEngine;
using System.Collections;

public class DampToOffset : MonoBehaviour {

	public Transform Target;
	public float DampAmount = 2f;

	float offset;
	Vector3 speed;

	void Start()
	{
		offset = (Target.position - transform.position).magnitude;
	}

	void Update()
	{
		transform.position = Vector3.SmoothDamp(transform.position, Target.position + Target.forward * offset, ref speed, DampAmount);
		transform.forward = Target.forward;
		//transform.up = Vector3.up;
		
	}
}
