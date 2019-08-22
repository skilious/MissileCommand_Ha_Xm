using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMissile : MonoBehaviour
{
    public static event Action<PlayerMissile> OnHitTarget = delegate { };

    [SerializeField]
    protected float Speed = 4.0f;

    protected bool _firing = false;
    protected Vector3 _target;

    public void AimAtTarget(Vector2 target, Vector2 origin)
    {
        _target = target;
        transform.position = origin;

        transform.rotation = Helper.GetLocalAngleBetweenVectors2((Vector2)origin, target);
    }

    public void Fire()
    {
        _firing = true;
    }

    void Update()
    {
        if(_firing)
        {
            transform.position += transform.right * 0.05f;

        }
    }


}


