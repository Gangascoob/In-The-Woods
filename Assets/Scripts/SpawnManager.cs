using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject Player;
    private Transform selectedSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnPoints.Length > 0)
        {
            selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        }
        Instantiate(Player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
