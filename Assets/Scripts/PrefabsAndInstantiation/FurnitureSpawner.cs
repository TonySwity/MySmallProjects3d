using UnityEngine;
using Random = UnityEngine.Random;

public class FurnitureSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _chairPrefab;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            Vector3 randomSpawnRotation = Vector3.up * Random.Range(0f, 306f);

            GameObject newChair = Instantiate(_chairPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
            newChair.transform.parent = transform;
        }
    }
}