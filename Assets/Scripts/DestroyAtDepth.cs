using UnityEngine;
using System.Collections;

public class DestroyAtDepth : MonoBehaviour
{
	public float MinY = -20f;

	void Update()
	{
		if(transform.position.y < MinY)
		{

		}
	}
}
