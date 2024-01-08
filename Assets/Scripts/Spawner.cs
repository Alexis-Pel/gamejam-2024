using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Target target;

    [SerializeField]
    private bool ToRight;


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
        Target spawned = Instantiate(target, transform);
        if (ToRight)
            spawned.Speed = Settings.TargetSpeed;
        else
            spawned.Speed = -Settings.TargetSpeed;
    }
}
