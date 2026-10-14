using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject PowerupPrefab;
    public int numEnemies = 3; //Number of enemies to start with
    private int enemyCount = 0;
    private int waveNumber = 0;

    //Random range that can be positive or negative between those ranges
    // This prevents the enemy from being on top or too close to the Player
    float RandRange(float first, float second)
    {
        float randomValue = Random.Range(6f, 8f);
        if (Random.value > 0.5f)
        {
            return (randomValue * -1f);
        }
        return randomValue;
    }

    Vector3 RandPos()
    {
        return new Vector3(RandRange(3f, 8f), 0f, RandRange(3f, 8f));
    }

    void SpawnEnemies(int nEnemies)
    {
        for(int i = 0; i < nEnemies; i++)
        {
            Instantiate(enemyPrefab, RandPos(), enemyPrefab.transform.rotation);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if(enemyCount == 0)
        {
            SpawnEnemies(numEnemies + waveNumber);
            Instantiate(PowerupPrefab, RandPos(), PowerupPrefab.transform.rotation);
            waveNumber++;
        }
    }
}
