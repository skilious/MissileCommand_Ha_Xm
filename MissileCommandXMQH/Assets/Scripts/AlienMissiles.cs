using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMissiles : MonoBehaviour
{

    public AlienMissiles _prefabMissile;
    public Transform _alienMissiles;
    public AlienManager _manager;

    [SerializeField]
    protected float Speed = 4.0f;

    protected bool _firing = false;
    protected Vector3 _target;
    public GameObject[] cities;

    [SerializeField]
    protected Sprite explosionSprite;
    private bool _explosion = false;

    int Rand = 0;
    private void Awake()
    {
        _manager = GameObject.Find("GameManager").GetComponent<AlienManager>();
        cities = GameObject.FindGameObjectsWithTag("Building");
    }

    private void Start()
    {
        Speed = Random.Range(1.0f, 2.0f);
        _alienMissiles = GetComponent<Transform>();

        Rand = Random.Range(0, 6);
        //Debug.Log("Random building target: " + Rand);
        _firing = true;
    }

   

    void Update()
    {
        if (_firing == true)
        {
            _alienMissiles.position = Vector3.MoveTowards(transform.position, cities[Rand].transform.position, Time.deltaTime * Speed);
        }

        if (_explosion)
        {
            //Expands the explosion once it hits the building.
            transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime * 4.0f;
        }
        //Using the helper's script to rotate the missiles with maths. Its basically LookAt but ignoring two axis except Z.
        transform.rotation = Helper.GetLocalAngleBetweenVectors2((Vector2)transform.position, cities[Rand].transform.position);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AlliedMissile")
        {
            //Minus Missile once its hit and the counter goes down.
            _manager.MissilesOnScreen--;
            //Before destroyed, gain points.
            Destroy(gameObject);

        }

        if (other.gameObject.tag == "Building")
        {
            StartCoroutine(Explosion());
            //Nested if statement by default to change the scaling of gameobject to 0 and expand the explosion afterwards once set to true.
            if (!_explosion)
            {
                transform.localScale = new Vector3(0, 0, 0);
                _explosion = true;
            }
        }
    }

    //Focuses on explosion of the gameobject and expanding.
    IEnumerator Explosion()
    {
        //Toggles firing off which stops the movement of the missile.
        _firing = false;
        //switches the sprite to the explosion.
        this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        //Changes the sprite color to red.
        this.GetComponent<SpriteRenderer>().color = Color.red;
        //Waits for two seconds and destroy the gameobject.
        yield return new WaitForSeconds(2.0f);
        _manager.MissilesOnScreen--;
        Destroy(gameObject);
    }
}
