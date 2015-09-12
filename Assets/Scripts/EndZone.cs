using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if(GameManager.CurrentState == GameManager.State.Playing && other.tag == "Player")
		{
			GameManager.Instance.GoToState(GameManager.State.Victory);
			other.gameObject.SetActive(false);
		}
	}
}
