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

    [SerializeField] AudioClip[] collideSound;
    
    Vector3 startPosition;
    float baseTravel;
    int randomAudio = 0;
    bool deathSound;

    private void Awake()
    {
        startPosition = transform.position;
        baseTravel = startPosition.z;
        startPosition.z = 0;
        deathSound = false;
        
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        float distanceTraveled = currentPosition.z - baseTravel;
        distanceCounter.text = Mathf.RoundToInt(distanceTraveled) + " Lightyears Traveled";
        if(Mathf.Abs(startPosition.x - currentPosition.x) > killWidth 
            || Mathf.Abs(startPosition.y - currentPosition.y) > killHeight)
        {
            StartCoroutine(GameOverSequence());

            if(!deathSound)
            {
                deathSound = true;
                gameObject.GetComponent<AudioSource>().clip = collideSound[3];
                gameObject.GetComponent<AudioSource>().pitch = 1;
                gameObject.GetComponent<AudioSource>().Play();
            }
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

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.layer == default)
        {
            randomAudio = Random.Range(0, 2);
            gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            gameObject.GetComponent<AudioSource>().clip = collideSound[randomAudio];
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
