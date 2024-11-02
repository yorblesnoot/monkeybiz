using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateTrigger : MonoBehaviour
{
    [SerializeField] float killHeight = 20;
    [SerializeField] float killWidth = 40;
    [SerializeField] float fadeDuration;
    [SerializeField] CanvasGroup gameOver;
    [SerializeField] TMP_Text distanceCounter;
    Vector3 startPosition;
    float baseTravel;
    private void Awake()
    {
        startPosition = transform.position;
        startPosition.z = 0;
        baseTravel = startPosition.z;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        float distanceTraveled = currentPosition.z + baseTravel;
        distanceCounter.text = Mathf.RoundToInt(distanceTraveled) + " Lightyears Traveled";
        if(Mathf.Abs(startPosition.x - currentPosition.x) > killWidth 
            || Mathf.Abs(startPosition.y - currentPosition.y) > killHeight)
        {
            StartCoroutine(GameOverSequence());
        }
    }

    IEnumerator GameOverSequence()
    {
        float timeElapsed = 0;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            gameOver.alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
