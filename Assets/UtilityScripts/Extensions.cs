using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public static class GameObjectExtensions
{
	public static T AddOrGetComponent<T>(this GameObject go) where T : Component
	{
		var exists = go.GetComponent<T>();
		if (exists != null)
			return exists;
		else
			return go.AddComponent<T>();
	}
}

public static class TransformExtensions
{
	public static void LocalPRSReset(this Transform t)
	{
		t.transform.localPosition = Vector3.zero;
		t.transform.localRotation = Quaternion.identity;
		t.transform.localScale = Vector3.one;
	}
}

public static class ComponentExtensions
{
	public static T AddOrGetComponent<T>(this Component c) where T : Component
	{
		return c.gameObject.AddOrGetComponent<T>();
	}
}

public static class CameraExtensions
{
	public static void Shake(this Camera c, float amount, float duration, int vibrato = 30)
	{
		c.transform.DOShakePosition(duration, Vector3.one * amount, vibrato);
		//iTween.ShakePosition(c.gameObject, Vector3.one * amount, duration);
	}
}


public static class ICollectionExt
{
	public static T RandomElement<T>(this ICollection<T> collection)
	{
		if (collection == null || collection.Count == 0)
		{
			throw new System.Exception("Attempted to get random element from empty/null collection");
		}

		int r = Random.Range(0, collection.Count);

		using (var enumer = collection.GetEnumerator())
		{
			for (int i = 0; enumer.MoveNext(); i++)
			{
				if (i == r)
					return enumer.Current;
			}
		}

		throw new System.Exception("wat");
	}

	public static T RandomElement<T>(this ICollection<T> collection, System.Random rand)
	{
		if(collection == null || collection.Count == 0)
		{
			throw new System.Exception("Attempted to get random element from empty/null collection");
		}

		int r = rand.Next(0, collection.Count);

		using (var enumer = collection.GetEnumerator())
		{
			for (int i = 0; enumer.MoveNext(); i++)
			{
				if (i == r)
					return enumer.Current;
			}
		}

		throw new System.Exception("wat");
	}
}

public static class VectorExtensions
{
	public static Vector4 IntCast(this Vector4 v)
	{
		return new Vector4((int)v.x, (int)v.y, (int)v.z, (int)v.w);
	}

	public static Vector3 IntCast(this Vector3 v)
	{
		return new Vector3((int)v.x, (int)v.y, (int)v.z);
	}

	public static Vector2 IntCast(this Vector2 v)
	{
		return new Vector2((int)v.x, (int)v.y);
	}
}

public static class SysRndExtensions
{
	public static float Next(this System.Random rnd, float min, float max)
	{
		return (float)rnd.NextDouble() * (max - min) + min;
	}
}