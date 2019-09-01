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

    protected SpriteRenderer _rend;

    public ScoreTrack _ScoreTrack;
    [SerializeField]
    protected bool _destroyed = false;

    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    public CityId Id
    {
        get { return _id; }
    }

    void Update()
    {
        if(_ScoreTrack._roundFinish == false)
        {
            _destroyed = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AlienMissile")
        {
            if(_destroyed == false)
            {
                _rend.enabled = false;
                _ScoreTrack._citiesHit++;
                _destroyed = true;
            }
        }
    }
}
