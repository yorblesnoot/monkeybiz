using System;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> levels;
    public int levelNumber = 0;

	private void OnTriggerEnter(Collider other)
	{
        
        //print($"levelSelector is: {levelSelector}");

        if (other.gameObject.CompareTag("New Section Trigger"))
        {
            int levelSelector = UnityEngine.Random.Range(0, levels.Count);
            Instantiate(levels[levelSelector], new Vector3(-15, 0, (levelNumber * 30 + 15)), Quaternion.identity);
            levelNumber++;
        }
	}
}
