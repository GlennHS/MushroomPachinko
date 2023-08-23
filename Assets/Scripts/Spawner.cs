using System.Collections;
using System.Collections.Generic;
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
        foreach(PegQuantity pq in pegs)
        {
            for(int i = 0; i < pq.quantity; i++)
                Instantiate(pq.pegObject, chooseSpawnLocation(pq.pegObject), Quaternion.identity);
        }
    }

    Vector2 chooseSpawnLocation(GameObject go)
    {
        // Okay so I didn't account for those PHAT pegs...
        float pegLargestDimension = Mathf.Max(go.transform.localScale.x, go.transform.localScale.y);

        float xLowerBound = transform.position.x - (transform.localScale.x / 2) + pegLargestDimension;
        float yLowerBound = transform.position.y - (transform.localScale.y / 2) + pegLargestDimension;
        float xUpperBound = transform.position.x + (transform.localScale.x / 2) - pegLargestDimension;
        float yUpperBound = transform.position.y + (transform.localScale.y / 2) - pegLargestDimension;

        return new Vector2(Random.Range(xLowerBound, xUpperBound), Random.Range(yLowerBound, yUpperBound));
    }
}
