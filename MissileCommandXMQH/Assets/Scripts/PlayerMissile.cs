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

    [SerializeField]
    protected Sprite explosionSprite;

    Vector3 point = new Vector3();
    Vector2 mousePos = new Vector2();
    void Start()
    {
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        point = Camera.main.ScreenToWorldPoint(mousePos);
    }
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
        float checkDistance = Vector2.Distance(transform.position, point);
        if (checkDistance <= 0.1f)
        {
            Debug.Log("Deleted!");
            StartCoroutine(Explosion());
        }

        if (_firing)
        {
            transform.position += transform.right * 0.05f;
        }
        Debug.Log("Mouse location: " + point + " Current missile pos: " + transform.position);
    }

    protected Vector3 Target
    {
        get
        {
            return _target;
        }

        set
        {
            _target = value;
        }
    }

    IEnumerator Explosion()
    {
        _firing = false;
        this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Explosion!");
        Destroy(gameObject);
    }

    
}


