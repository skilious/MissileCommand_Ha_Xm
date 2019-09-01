using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum CityId
{
    CITY_1 = 0,
    CITY_2,
    CITY_3,
    CITY_4,
    CITY_5,
    CITY_6,

    CITY_COUNT
}

public class CityManager : MonoBehaviour
{
    protected City[] _cities;

    [SerializeField]
    protected SpriteRenderer[] _spriteRends;

    private void Awake()
    {
        _cities = GetComponentsInChildren<City>();
        _cities = _cities.OrderBy(City => City.Id).ToArray();
    }

    public void Reset()
    {
        for(int i = 0; i < (int)CityId.CITY_COUNT; i++)
        {
            _spriteRends[i].enabled = true;
        }
    }

    public City GetCityById(CityId id)
    {
        foreach (City city in _cities)
        {
            if (id == city.Id)
                return city;
        }
        return null;
    }

    public Vector2 GetCityPosition(CityId id)
    {
        return (_cities[(int)id].transform.position);
    }
}
