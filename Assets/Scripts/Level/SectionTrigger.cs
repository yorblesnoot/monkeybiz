using System;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject levelSection;
    public GameObject levelSection2;
    public GameObject levelSection3;
    public int levelNumber = 0;
    public int levelSelector = 1;
    public string levelGenerated = "Nope";

	private void OnTriggerEnter(Collider other)
	{
        levelSelector = UnityEngine.Random.Range(1, 4);
        //print($"levelSelector is: {levelSelector}");

        if (other.gameObject.CompareTag("New Section Trigger"))
        {
            if (levelSelector == 1)
            {
                //levelGenerated = "LevelSelection";
				Instantiate(levelSection, new Vector3(-15, 0, (levelNumber * 30 + 15)), Quaternion.identity);
			}
            else if (levelSelector == 2)
            {
				//levelGenerated = "LevelSelection2";
				Instantiate(levelSection2, new Vector3(-15, 0, (levelNumber * 30 + 15)), Quaternion.identity);
			}
            else if (levelSelector == 3)
            {
				//levelGenerated = "LevelSelection3";
				Instantiate(levelSection3, new Vector3(-15, 0, (levelNumber * 30 + 15)), Quaternion.identity);
			}
            else
            {
                Console.WriteLine(levelGenerated, " we may have a problem");
            }

			print($"level Generated is: {levelGenerated}");
            levelNumber++;
        }
	}
}
