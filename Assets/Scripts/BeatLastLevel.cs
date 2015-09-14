using UnityEngine;

public class BeatLastLevel : MonoBehaviour
{
	public void Update()
	{
		if(GameManager.CurrentLevelIndex < GameManager.Instance.Levels.Count - 1)
		{
			gameObject.SetActive(false);
		}

		if(GameManager.CurrentState != GameManager.State.Playing && 
			Input.GetButtonDown("Submit"))
		{
			GameManager.Instance.GoToLevel(-1);
			GameManager.Instance.GoToState(GameManager.State.Intro);
		}
	}
}
