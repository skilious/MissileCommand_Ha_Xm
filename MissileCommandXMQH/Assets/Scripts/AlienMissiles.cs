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

    [SerializeField]
    protected Sprite explosionSprite;
    private bool _explosion = false;

    int Rand = 0;
    private void Awake()
    { 
        cities = GameObject.FindGameObjectsWithTag("Building");
    }

    private void Start()
    {
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
        transform.rotation = Helper.GetLocalAngleBetweenVectors2((Vector2)transform.position, cities[Rand].transform.position);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AlliedMissile")
        {
            Destroy(gameObject);
            
        }

        if (other.gameObject.tag == "Building")
        {
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        //Toggles firing off which stops the movement of the missile.
        _firing = false;

        //switches the sprite to the explosion.
        this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        this.GetComponent<SpriteRenderer>().color = Color.white;

        //Expanding the explosion.
        transform.localScale += new Vector3(0.3f, 0.3f, 0.3f) * Time.deltaTime * 4.0f;

        //Waits for two seconds and destroy the gameobject.
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
