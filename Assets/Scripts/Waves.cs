using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    [Header("WaveControl")]
    public Wave[] waves;
    Enemy enemy;
    Wave currentWave;
    int currentWaveNumber = 0;
    int bossIdx;

    public float waveTime;
    float waveCountdown;

    int enemiesRemainingAlive;
    int enemiesRemaningToSpawn;
    float nextSpawnTime;
    public bool spawnWave;
    public float spawnDist;

    [Header("Other Objects")]
    public GameObject ui;
    public GameObject player;


    void Start()
    {

        // get wave ui
        ui = GameObject.FindGameObjectWithTag("ScreenCanvas");
        player = GameObject.FindGameObjectWithTag("Player");
        waveCountdown = waveTime;
        Invoke("NextWave", waveCountdown);
    }

    void Update()
    {
        if (player.GetComponent<Movement>().dead)
        {
            spawnWave = false;
        }
        ui.GetComponent<UI>().waveTime = waveCountdown;
        Vector3 spawnPoint = checkDist(spawnDist);
        if (waveCountdown <= 0)
        {
            if (spawnWave != false)
            {
                if (enemiesRemaningToSpawn > 0 && Time.time > nextSpawnTime)
                {

                    enemiesRemaningToSpawn--;

                    nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
                    Enemy spawnedEnemy = Instantiate(enemy, checkDist(spawnDist), Quaternion.identity) as Enemy;
                    spawnedEnemy.OnDeath += OnEnemyDeath;
                }
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

        if (waveCountdown < 0)
        {
            waveCountdown = 0;
        }
    }

    Vector3 checkDist(float spawnDist)
    {
        float dist;

        Vector3 loc = new Vector3(Random.Range(-45, 45), 0, Random.Range(45, -20));
        dist = Vector3.Distance(player.transform.position, loc);

        while (dist <= spawnDist)
        {
            loc = new Vector3(Random.Range(-45, 45), 0, Random.Range(45, -20));
            dist = Vector3.Distance(player.transform.position, loc);
        }

        return loc;
    }

    void OnEnemyDeath()
    {
        print("Enemy Died");
        enemiesRemainingAlive--;
        if (enemiesRemainingAlive <= 0)
        {
            if (waveCountdown <= 0)
            {
                waveCountdown = waveTime;
                NextWave();
            }
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];

            ui.GetComponent<UI>().wave = currentWaveNumber;

            enemiesRemaningToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemaningToSpawn;
            enemy = currentWave.enemy;

        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
        public Enemy enemy;
    }
}
