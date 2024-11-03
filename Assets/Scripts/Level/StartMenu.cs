using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	void Update()
	{
		if (Input.anyKeyDown)
		{
			gameObject.GetComponent<AudioSource>().Play();
			StartCoroutine(LoadGame());
		}

		IEnumerator LoadGame()
        {
			yield return new WaitForSeconds(0.8f);
			SceneManager.LoadScene(1);
		}
	}
}
