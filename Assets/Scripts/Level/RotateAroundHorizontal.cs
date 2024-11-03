using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundHorizontal : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] int spinDirection = 1;
    //spinSpeed is number of degrees covered per second
    [SerializeField] int spinSpeed = 90;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, spinSpeed * spinDirection * Time.deltaTime);
    }
}
