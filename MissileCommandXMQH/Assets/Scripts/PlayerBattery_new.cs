using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattery_new : MonoBehaviour
{
    [SerializeField]
    protected PlayerMissile PrefabMissiles;

    private static readonly int CAPACITY = 10;
    protected int _rounds = 0;
    private static int MOUSE = 0;
    private List<GameObject> batteries;

    void Awake()
    {

        _rounds = CAPACITY;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MOUSE = 0;
            Debug.Log("LEFT");
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            MOUSE = 1;
            Debug.Log("RIGHT");
        }

        if (Input.GetMouseButtonDown(2))
        {
            MOUSE = 2;
            Debug.Log("MIDDLE");
        }
    }
}
