using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<T>();
			}
			return instance;
		}
	}

	protected virtual void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this as T;
		}
	}
}
