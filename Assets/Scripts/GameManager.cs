using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

	public enum State
	{
		Playing,
		Victory,
		Loss
	}

	public static State CurrentState { get; private set; }

	public List<GameObject> PlayingObjs = new List<GameObject>();

	public void GoToState(State state)
	{
		CurrentState = state;
	}
}
