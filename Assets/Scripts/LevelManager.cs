using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public float timeTillNextLevel = 5.0f;
	// Use this for initialization
	void Start ()
	{



	}
	
	// Update is called once per frame
	void Update ()
	{
		timeTillNextLevel -= Time.deltaTime;
		if (Input.GetKeyDown ("space")) {
			LoadNextScene ();
		}

		if (timeTillNextLevel <= 0) {
			LoadNextScene ();
		}
	}

	public void LoadNextScene ()
	{
		int currentIndex =	SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentIndex + 1);
	}

	public void PreviousScene ()
	{
		int currentIndex =	SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentIndex - 1);
	}
		
}
