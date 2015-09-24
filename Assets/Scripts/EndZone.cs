using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if(GameManager.CurrentState == GameManager.State.Playing && other.tag == "Player")
		{
			GameManager.Instance.GoToState(GameManager.State.Victory);

			var particles = Instantiate(Resources.Load("VictoryParticles") as GameObject) as GameObject;
			particles.transform.position = other.transform.position;
			particles.transform.forward = Vector3.up;
			particles.SetActive(true);

			other.gameObject.SetActive(false);

		}
	}
}
