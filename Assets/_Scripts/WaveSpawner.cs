using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject medusaPrefab;
    public GameObject ghostPrefab;
    public Transform ghostSpawnPoint;
    public Transform medusaSpawnPoint;

    [HideInInspector]
    public int ghostCounter = 0;

    public float timeBetweenWaves;
    private float countDown = 3f;

    private int waveIndex = 0;

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        SpawnMedusa();
        yield return new WaitForSeconds(1F);
        SpawnGhost();
        yield return new WaitForSeconds(2F);
    }

    void SpawnGhost()
    {
        if (ghostCounter <= 10)
        {
            Instantiate(ghostPrefab, ghostSpawnPoint.position, ghostSpawnPoint.rotation);
            ghostCounter++;
        }
    }

    void SpawnMedusa()
    {
        
        Instantiate(medusaPrefab, medusaSpawnPoint.position, medusaSpawnPoint.rotation);
        
    }
}
