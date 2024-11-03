using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoundRoll : MonoBehaviour
{
	public GameObject target;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Spin the object around the target at X degrees/second.
		transform.RotateAround(target.transform.position, Vector3.left, 90 * Time.deltaTime);
	}
}
