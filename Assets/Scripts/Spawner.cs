using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private bool ToRight;

    [SerializeField]
    private GameObject[] Targets;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), Settings.SpawnFreq, Settings.SpawnFreq);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnTarget()
    {
        GameObject target = Targets[Random.Range(0, Targets.Length)];
        Target spawned = Instantiate(target, transform).GetComponent<Target>();
        spawned.goRight = ToRight;
    }
}
