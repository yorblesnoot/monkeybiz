using System;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> levels;
    public int levelNumber = 0;
    [SerializeField] int levelBuffer = 3;
    [SerializeField] int levelSize = 30;

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
        Instantiate(levels[levelSelector], new Vector3(-15, 0, (levelNumber * levelSize)), Quaternion.identity);
        levelNumber++;
    }
}
