using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;


	private Quaternion m_CharacterTargetRot;


	public void Start()
	{
		m_CharacterTargetRot = transform.localRotation;
#if !UNITY_EDITOR
		enabled = false;
#endif
	}


	public void Update()
	{
		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

		m_CharacterTargetRot *= Quaternion.Euler(-xRot, yRot, 0f);

		if (clampVerticalRotation)
			m_CharacterTargetRot = ClampRotationAroundXAxis(m_CharacterTargetRot);

		if (smooth)
		{
			transform.localRotation = Quaternion.Slerp(transform.localRotation, m_CharacterTargetRot,
				smoothTime * Time.deltaTime);
		}
		else
		{
			transform.localRotation = m_CharacterTargetRot;
		}
	}


	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

		angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

		q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}

}

