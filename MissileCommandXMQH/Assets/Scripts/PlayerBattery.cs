﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattery : MonoBehaviour
{
    [SerializeField]
    protected PlayerMissile MissilePrefab;

    [SerializeField]
    protected AlienManager _alienManager;

    public static readonly int CAPACITY = 10;
    
    private bool isAlive = false;
    private int _rounds = 0;
    private SpriteRenderer _spriteRend;

    private void Awake()
    {
        _rounds = CAPACITY;

        _spriteRend = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (_alienManager.MissilesOnScreen <= 0 && _alienManager.Timer <= 0.2f)
        {
            _rounds = CAPACITY;
            _spriteRend.enabled = true;
            _spriteRend.sprite = SpriteAtlasManager.Instance.GetSprite(SpriteAtlasManager.BATTERY_ATLAS, _rounds);
        }
    }

    public bool isArmed()
    {
        return (isAlive && _rounds > 0);
    }
    
    public PlayerMissile FireMissileAt(Vector2 target, Vector2 origin)
    {
        PlayerMissile missile = null;
        if(_rounds > 0)
        {
            missile = Instantiate(MissilePrefab);
            missile.AimAtTarget(target, origin);
            missile.Fire();

            Rounds--;
        }
        return (missile);
    }

    private int Rounds
    {
        get { return _rounds; }
        set
        {
            if(value >= 0 && value <= CAPACITY)
            {
                _rounds = value;
                if(_rounds > 0)
                {
                    _spriteRend.enabled = true;

                    _spriteRend.sprite = SpriteAtlasManager.Instance.GetSprite(SpriteAtlasManager.BATTERY_ATLAS, _rounds);
                }
                else
                {
                    _spriteRend.enabled = false;
                }
            }
        }
    }

    public void Reset()
    {
        return;
    }
}
