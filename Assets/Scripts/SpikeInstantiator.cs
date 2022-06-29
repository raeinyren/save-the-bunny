using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeInstantiator : MonoBehaviour
{
    public GameObject spikes;
    public float istantiatingSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSpikes", 1f, istantiatingSpeed);
    }

    public void SpawnSpikes(){
        Instantiate(spikes, new Vector2(Random.Range(-2.65f, 2.65f), transform.position.y), Quaternion.identity);
    }

    public void StopSpawning(){
        CancelInvoke("SpawnSpikes");
    }
}
