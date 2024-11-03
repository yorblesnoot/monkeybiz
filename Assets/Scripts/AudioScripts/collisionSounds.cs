using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionSounds : MonoBehaviour
{

    [SerializeField] AudioClip[] collideSound;

    int randomAudio = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == default)
        {
            randomAudio = Random.Range(0, 2);
            gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            gameObject.GetComponent<AudioSource>().clip = collideSound[randomAudio];
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
