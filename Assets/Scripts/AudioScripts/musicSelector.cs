using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSelector : MonoBehaviour
{
    [SerializeField] AudioClip[] music;

    AudioSource musicSource;
    bool musicSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = gameObject.GetComponent<AudioSource>();
        musicSource.pitch = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<Rigidbody>().velocity == Vector3.zero)
        {
            musicSource.clip = music[0];
            musicSwitch = false;
        }
        else
        {
            musicSource.clip = music[1];
            if (!musicSwitch)
            {
                musicSwitch = true;
                musicSource.Play();
            }
        }
    }
}
