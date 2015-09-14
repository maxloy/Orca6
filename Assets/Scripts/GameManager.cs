using UnityEngine;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{

	public enum State
	{
		Intro,
		Playing,
		Victory,
		Loss
	}

	public static State CurrentState { get; private set; }
	public static GameObject CurrentLevel { get; private set; }
	public static int CurrentLevelIndex { get; private set; }

	public List<GameObject> Levels = new List<GameObject>();

	public List<GameObject> IntroObjs = new List<GameObject>();
	public List<GameObject> PlayingObjs = new List<GameObject>();
	public List<GameObject> VictoryObjs = new List<GameObject>();
	public List<GameObject> LossObjs = new List<GameObject>();

	Dictionary<State, List<GameObject>> stateObjs;


	public void Start()
	{
		stateObjs = new Dictionary<State, List<GameObject>>()
		{
			{State.Intro, IntroObjs },
			{State.Playing, PlayingObjs },
			{State.Victory, VictoryObjs },
			{State.Loss, LossObjs }
		};

		foreach(var level in Levels)
		{
			level.SetActive(false);
		}

		GoToLevel(-1);
		GoToState(State.Intro);
	}

	public void GoToLevel(int level)
	{
		if (level < -1 || level >= Levels.Count)
		{
			throw new System.IndexOutOfRangeException();
		}

		if(CurrentLevel != null)
			Destroy(CurrentLevel);

		if (level != -1)
		{
			CurrentLevel = Instantiate(Levels[level]) as GameObject;
			CurrentLevel.SetActive(true);
		}

		CurrentLevelIndex = level;
	}

	public void GoToState(State state)
	{
		CurrentState = state;
		foreach (var pair in stateObjs)
		{
			foreach (var obj in pair.Value)
			{
				obj.SetActive(state == pair.Key);
			}
		}
	}

	void Update()
	{
		if(Input.GetButton("Start"))
		{
			GoToLevel(-1);
			GoToState(State.Intro);
		}
	}
}
