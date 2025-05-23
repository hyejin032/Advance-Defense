using System.Collections;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Vector3 SpawnPosition;
    public float MinTime = 1f;
    public float MaxTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(MinTime, MaxTime);
            yield return new WaitForSeconds(waitTime);

            Instantiate(EnemyPrefab, SpawnPosition, Quaternion.identity);
        }
    }
}