using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform character;
    float lockedX;
    float lockedY;

    private void Awake()
    {
        lockedX = transform.position.x;
        lockedY = transform.position.y;
    }

    private void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = lockedX;
        cameraPosition.y = lockedY;
        transform.position = cameraPosition;
    }
}
