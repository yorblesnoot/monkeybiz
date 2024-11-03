using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockwiseRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	int rotationsPerMinute = 12;
	// Update is called once per frame
	void Update()
	{
		transform.Rotate(6.0f * rotationsPerMinute * Time.deltaTime, 0, 0);
	}
}
