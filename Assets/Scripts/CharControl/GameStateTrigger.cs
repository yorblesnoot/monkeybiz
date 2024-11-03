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
    [SerializeField] AudioClip[] collideSound;
    int randomAudio = 0;
    bool deathSound;
    bool offScreen = false;
    Vector3 startPosition;
    int score = 0;
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
    }

    IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(deathDelay);
        if (!offScreen) yield break;
        if (!deathSound)
        {
            deathSound = true;
            gameObject.GetComponent<AudioSource>().clip = collideSound[2];
            gameObject.GetComponent<AudioSource>().pitch = 1;
            gameObject.GetComponent<AudioSource>().Play();
        }
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
