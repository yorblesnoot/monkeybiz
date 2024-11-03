using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateXaxis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] int rotationsPerMinute = 10;
    [SerializeField] int spinDirection = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(6.0f * spinDirection * rotationsPerMinute * Time.deltaTime, 0, 0);
    }
}
