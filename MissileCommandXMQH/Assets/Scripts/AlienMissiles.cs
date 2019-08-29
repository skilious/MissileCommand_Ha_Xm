using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMissiles : MonoBehaviour
{

    public AlienMissiles _prefabMissile;
    public Transform _alienMissiles;

    [SerializeField]
    protected float Speed = 4.0f;

    protected bool _firing = false;
    protected Vector3 _target;
    public GameObject[] cities;

    int Rand = 0;
    private void Awake()
    { 
        cities = GameObject.FindGameObjectsWithTag("Building");
    }

    private void Start()
    {
        _alienMissiles = GetComponent<Transform>();

        Rand = Random.Range(0, 6);
        Debug.Log("Random building target: " + Rand);
    }

   

    void Update()
    {
        _alienMissiles.position = Vector3.MoveTowards(transform.position, cities[Rand].transform.position, Time.deltaTime * Speed);
        
    }
}
