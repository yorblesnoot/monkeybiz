using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraControl : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] Transform character;

    VolumeProfile profile;

    private void Awake()
    {
        offset = transform.position - character.position;
        profile = gameObject.GetComponent<Volume>().sharedProfile;
    }

    private void LateUpdate()
    {
        if (!profile.TryGet<ChromaticAberration>(out var chromabe))
        {
            chromabe = profile.Add<ChromaticAberration>(false);
        }
        if (!profile.TryGet<FilmGrain>(out var filmgrain))
        {
            filmgrain = profile.Add<FilmGrain>(false);
        }
        if (!profile.TryGet<ColorAdjustments>(out var coloradj))
        {
            coloradj = profile.Add<ColorAdjustments>(false);
        }


        Vector3 target = character.position + offset;
        target.y = transform.position.y;
        target.x = transform.position.x;
        Vector3 newPosition = Vector3.Lerp(transform.position, target, Time.deltaTime*4);

        chromabe.intensity.value = (newPosition - transform.position).magnitude*4;
        filmgrain.intensity.value = (newPosition - transform.position).magnitude*4;
        coloradj.hueShift.value = (newPosition - transform.position).magnitude * 100 - 2;

        transform.position = newPosition;
    }

}
