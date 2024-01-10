using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private bool ToRight;

    private GameObject[] Targets;

    private float spawnTime;

    public GameManager gameManager;

    public WaveScriptable[] waves;

    private int WaveIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        Settings.SpawnFreqMax = waves[WaveIndex].enemyRateMax;
        Targets = waves[WaveIndex].targets;
        SetSpawnTime();
        Invoke(nameof(SpawnTarget), spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Settings.Score >= 10 && WaveIndex < 1)
        {
            ChangeWave();
        }
    }

    private void SpawnTarget()
    {
        GameObject target = Targets[Random.Range(0, Targets.Length)];
        Target spawned = Instantiate(target, transform).GetComponent<Target>();
        spawned.goRight = ToRight;
        SetSpawnTime();
        Invoke(nameof(SpawnTarget), spawnTime);
    }

    private void SetSpawnTime()
    {
        spawnTime = Random.Range(1, Settings.SpawnFreqMax);
    }

    private void ChangeWave()
    {
        WaveIndex += 1;
        Settings.SpawnFreqMax = waves[WaveIndex].enemyRateMax;
        Targets = waves[WaveIndex].targets;
    }
}
