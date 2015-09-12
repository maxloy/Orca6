using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour
{


	void Update()
	{
		if(Input.GetButtonDown("Submit") && GameManager.CurrentState != GameManager.State.Playing)
		{
			GameManager.Instance.GoToLevel(GameManager.CurrentLevelIndex);
			GameManager.Instance.GoToState(GameManager.State.Playing);
		}
	}
}
