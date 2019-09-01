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

    private bool _explosion = false;

    public float RandExpansion;

    Vector3 point = new Vector3();
    Vector2 mousePos = new Vector2();

    void Start()
    {
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        //Grabs the mouse position from the main camera to world point.
        point = Camera.main.ScreenToWorldPoint(mousePos);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

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
        //Checks the distance between gameobject and mouse position.
        float checkDistance = Vector2.Distance(transform.position, point);
        if (checkDistance <= 0.3f)
        {
            //It defaults to false once called in the nested if statement with the scale of gameobject to 0 and switches bool statement to true.
            if (!_explosion)
            {

                RandExpansion = UnityEngine.Random.Range(1.0f, 2.5f);
                transform.localScale = new Vector3(0, 0, 0);
                _explosion = true;
            }
            //Starts the IEnumerator Explosion().
            StartCoroutine(Explosion());
        }
        //If firing, it shoots the missile out to the location by mouse position with 0.1f speed.
        if (_firing)
        {
            transform.position += transform.right * Speed;
        }
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
        //Toggles firing off which stops the movement of the missile.
        _firing = false;
        //switches the sprite to the explosion.
        this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        //this another bool to check if explosion is true and expands the explosion.
        if (_explosion)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime * 15.0f;
        }
        //Waits for RANDEXPANSION (RANDOM BETWEEN 1.0F - 2.5F) seconds and destroy the gameobject.
        yield return new WaitForSeconds(RandExpansion);
        Destroy(gameObject);
    }


}


