using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattery : MonoBehaviour
{
    [SerializeField]
    protected PlayerMissile MissilePrefab;

    public static readonly int CAPACITY = 10;
    
    private bool isAlive = false;
    private int _rounds = 0;
    private SpriteRenderer _spriteRend;

    private void Awake()
    {
        _rounds = CAPACITY;

        _spriteRend = gameObject.GetComponentInChildren<SpriteRenderer>();
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
                }
                else
                {
                    _spriteRend.enabled = false;
                }
            }
        }
    }
}
