using UnityEngine;
using System.Collections;

public class DestroyInTime: MonoBehaviour
{
	public float Duration = 1f;

	float EndTime = 0;

	void OnEnable()
	{
		EndTime = Time.time + Duration;
	}

	void Update()
	{
		if(Time.time > EndTime)
		{
			gameObject.Recycle();
		}
	}
}
