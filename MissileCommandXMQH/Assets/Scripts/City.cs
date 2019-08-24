using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CityStatus
{
    STANDING,
    EXPLODING,
    CARATER
}
public class City : MonoBehaviour
{
    [SerializeField]
    protected CityId _id;
    void Update()
    {
        
    }

    public CityId Id
    {
        get { return _id; }
    }
}
