using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] _targets;
    public GameObject _missiles;
    private int Rand = 9;

    void Start()
    {
           
    }

    

    void Update()
    {
        if (Rand >= 0)
        {
            int RandSpawn = 0;
            RandSpawn = Random.Range(0, 2);
            Instantiate(_missiles, spawnPoints[RandSpawn].transform.position, Quaternion.identity);
            Debug.Log(" Random Building: " + RandSpawn);
            Rand--;
        }
    }
}
