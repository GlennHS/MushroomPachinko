using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct PegQuantity
    {
        public GameObject pegObject;
        public int quantity;
    }

    [SerializeField]
    public PegQuantity[] pegs;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> currentPegs = new List<GameObject>();

        foreach (PegQuantity pq in pegs)
        {
            for (int i = 0; i < pq.quantity; i++)
            {
                Vector2 proposedPosition = chooseSpawnLocation(pq.pegObject, currentPegs);
                currentPegs.Add(Instantiate(pq.pegObject, proposedPosition, Quaternion.identity));
            }
        }
    }


    Vector2 chooseSpawnLocation(GameObject go, List<GameObject> currentPegs)
    {
        float pegLargestDimension = Mathf.Max(go.transform.localScale.x, go.transform.localScale.y);

        float xLowerBound = transform.position.x - (transform.localScale.x / 2) + pegLargestDimension;
        float yLowerBound = transform.position.y - (transform.localScale.y / 2) + pegLargestDimension;
        float xUpperBound = transform.position.x + (transform.localScale.x / 2) - pegLargestDimension;
        float yUpperBound = transform.position.y + (transform.localScale.y / 2) - pegLargestDimension;

        int maxTries = 50;  // Maximum attempts to find a valid position
        int currentTry = 0;
        Vector2 proposedPosition = Vector2.zero;

        while (currentTry < maxTries)
        {
            proposedPosition = new Vector2(Random.Range(xLowerBound, xUpperBound), Random.Range(yLowerBound, yUpperBound));

            bool positionIsValid = true;
            foreach (GameObject existingPeg in currentPegs)
            {
                float distance = Vector2.Distance(proposedPosition, existingPeg.transform.position);
                if (distance < pegLargestDimension * 4)  // Adjust the factor as needed
                {
                    positionIsValid = false;
                    break;
                }
            }

            if (positionIsValid)
            {
                return proposedPosition;
            }

            currentTry++;
        }

        // If no valid position is found after maxTries, return a default position or handle it accordingly
        Debug.Log("Spawning default case hit...");
        return proposedPosition;
    }
}
