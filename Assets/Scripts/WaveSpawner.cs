using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;

    public float timeBetweenWaves = 15f;
    private float countdown = 2f;
    private int waveIndex = 0;
    private int index = 0;

    public Transform spawnPoint;
    public Text waveCountDownText;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = "Time to new wave: " + Math.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[index];

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(0.8f);
        }

        index++;

        if (index >= waves.Length) index = 0;

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
