using UnityEngine;

public class GoToNextLevel : MonoBehaviour
{


	public void Update()
	{
		if(GameManager.CurrentState != GameManager.State.Playing && GameManager.CurrentLevelIndex < GameManager.Instance.Levels.Count - 1)
		{
			GameManager.Instance.GoToLevel(GameManager.CurrentLevelIndex + 1);
			GameManager.Instance.GoToState(GameManager.State.Playing);
		}
	}
}
