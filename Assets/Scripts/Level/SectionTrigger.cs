using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> levels;
    public int levelNumber = 0;
    [SerializeField] int levelBuffer = 3;
    [SerializeField] int levelSize = 30;
    [SerializeField] string dissolveField = "_DissolveLevel";
    [SerializeField] float dissolveDuration = .5f;

    private void Awake()
    {
        for (int i = 0; i < levelBuffer; i++)
        {
            InstantiateBiome();
        }
    }

    private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("New Section Trigger"))
        {
            InstantiateBiome();
        }
    }

    private void InstantiateBiome()
    {
        int levelSelector = UnityEngine.Random.Range(0, levels.Count);
        GameObject spawned = Instantiate(levels[levelSelector], new Vector3(-15, 0, (levelNumber * levelSize)), Quaternion.identity);
        levelNumber++;
        Material[] materials = spawned.GetComponentsInChildren<Renderer>().Select(r => r.material).ToArray();
        if (materials == null) return;
        foreach(var material in materials) material.SetFloat(dissolveField, 0);
        StartCoroutine(FadeIn(materials));
        
    }

    IEnumerator FadeIn(Material[] materials)
    {
        float timeElapsed = 0;
        while(timeElapsed < dissolveDuration)
        {
            yield return null;
            timeElapsed += Time.deltaTime;
            foreach (var material in materials)
                material.SetFloat(dissolveField, Mathf.Lerp(0, 1, timeElapsed/dissolveDuration));
        }
    }
}
