using UnityEngine;
using System.Collections;

public class ControlArea : MonoBehaviour {

	static RotateWithInput active;

	public RotateWithInput Target;
	
	void Awake()
	{
		Target.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		var body = other.GetComponent<Rigidbody>();
		if(body != null && body.isKinematic == false)
		{
			if (active != null)
				active.enabled = false;
			active = Target;
			Target.enabled = true;
		}
	}
}
