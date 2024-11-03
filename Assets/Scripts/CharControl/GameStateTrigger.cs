using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateTrigger : MonoBehaviour
{
    [SerializeField] float deathDelay = 1;
    [SerializeField] float velocityPerMultiplier = 10;
    [SerializeField] float fadeDuration;
    [SerializeField] CanvasGroup gameOver;
    [SerializeField] TMP_Text distanceCounter;
    [SerializeField] Rigidbody playerBody;
    [SerializeField] GameObject gibs;
    [SerializeField] GameObject[] controls;
    bool deathSound;
    bool offScreen = false;
    Vector3 startPosition;
    int score = 0;
    int finalScore = 0;

    private void Awake()
    {
        startPosition = transform.position;
        startPosition.z = 0;
    }

    private void OnBecameInvisible()
    {
        StartCoroutine(GameOverSequence());
        offScreen = true;
    }

    private void OnBecameVisible()
    {
        offScreen = false;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        int speedMultiplier = Mathf.RoundToInt(playerBody.velocity.magnitude/velocityPerMultiplier);
        score += speedMultiplier;

        distanceCounter.text = score + " x" + speedMultiplier;

        if (offScreen == true)
        {
            distanceCounter.text = finalScore.ToString();
        }
        else if (playerBody.velocity.magnitude == 0)
        {
            distanceCounter.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        }
    }

    IEnumerator GameOverSequence()
    {
        Vector3 gibPosition = transform.position;
        finalScore = score;
        yield return new WaitForSeconds(deathDelay);
        if (!offScreen) yield break;
        if (!deathSound)
        {
            deathSound = true;
            gameObject.GetComponent<AudioSource>().Play();
        }

        SpawnGibs(gibPosition);
        float timeElapsed = 0;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            gameOver.alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
        }
        gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        controls[0].GetComponent<Grapple>(). enabled = false;
        controls[1].GetComponent<Grapple>().enabled = false;

        yield return new WaitForSeconds(3);
        
        if(PlayerPrefs.GetInt("highScore") < finalScore)
        {
            PlayerPrefs.SetInt("highScore", finalScore);
        }
        SceneManager.LoadScene(0);
    }

    private void SpawnGibs(Vector3 position)
    {
        GameObject spawned = Instantiate(gibs, position, Quaternion.identity);
        Vector3 targetPosition = Camera.main.transform.position;
        targetPosition.z = transform.position.z;
        spawned.transform.LookAt(targetPosition);
    }
}
