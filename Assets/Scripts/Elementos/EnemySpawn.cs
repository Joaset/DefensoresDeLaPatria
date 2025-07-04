using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave
{
    public int meleeCount;
    public int rangedCount;
    public float spawnDelay;
}

public class EnemySpawn : MonoBehaviour
{
    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;
    public Transform[] spawnPoints;
    public Wave[] waves;
    public float timeBetweenWaves;
    private System.Action onWavesDone;

    private int currentWave = 0;
    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        //StartCoroutine(SpawnWaveRoutine());
    }

    public void StartWaveSequence(System.Action callback)
    {
        onWavesDone = callback;
        StartCoroutine(SpawnWaveRoutine());
    }

    IEnumerator SpawnWaveRoutine()
    {
        while (currentWave < waves.Length)
        {
            yield return StartCoroutine(SpawnWave(waves[currentWave]));
            yield return new WaitUntil(() => activeEnemies.Count == 0);
            currentWave++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        onWavesDone?.Invoke();
        Debug.Log("Todas las oleadas completadas.");
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log($"Oleada {currentWave + 1} iniciada.");

        for (int i = 0; i < wave.meleeCount; i++)
        {
            SpawnEnemy(meleeEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnDelay);
        }

        for (int i = 0; i < wave.rangedCount; i++)
        {
            SpawnEnemy(rangedEnemyPrefab);
            yield return new WaitForSeconds(wave.spawnDelay);
        }

        Debug.Log($"Oleada {currentWave + 1} completa.");
    }

    void SpawnEnemy(GameObject prefab)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        activeEnemies.Add(enemy);

        // Escuchamos la muerte del enemigo
        EnemyController baseController = enemy.GetComponent<EnemyController>();
        if (baseController != null)
        {
            baseController.OnDeath += () => activeEnemies.Remove(enemy);
        }
    }
}
