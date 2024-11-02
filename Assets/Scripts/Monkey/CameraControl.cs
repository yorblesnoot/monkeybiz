using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] Transform character;

    private void Awake()
    {
        offset = transform.position - character.position;
    }

    private void LateUpdate()
    {
        Vector3 target = character.position + offset;
        target.y = transform.position.y;
        target.x = transform.position.x;
        Vector3 newPosition = Vector3.Lerp(transform.position, target, Time.deltaTime);
        transform.position = newPosition;
    }
}
