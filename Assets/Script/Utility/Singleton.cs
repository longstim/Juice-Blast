using UnityEngine;

/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// 
/// As a note, this is made as MonoBehaviour because we need Coroutines.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;
	
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = (T)FindObjectOfType(typeof(T));
				
				if (_instance == null)
				{
					//Debug.LogWarning("[Singleton] Singleton of " + typeof(T).ToString() + " not found!");
				}
				
				if (FindObjectsOfType(typeof(T)).Length > 1)
				{
					Debug.LogWarning("[Singleton] " + typeof(T).ToString()  + " Something went really wrong " +
					                 " - there should never be more than 1 singleton!" +
					                 " Reopening the scene might fix it.");
				}
			}
			
			return _instance;
		}
	}
	
}