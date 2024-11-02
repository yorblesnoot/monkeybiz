using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateVerticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int rotationsPerMinute = 10;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }
}
