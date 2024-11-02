using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject levelSection;
    public int levelNumber = 0;

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("New Section Trigger"))
        {
            Instantiate(levelSection, new Vector3(-15, 0, (levelNumber * 30 + 15)), Quaternion.identity);
            levelNumber++;
        }
	}
}
