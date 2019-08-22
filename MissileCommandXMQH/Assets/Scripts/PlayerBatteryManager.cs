using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum PlayerBatteryId
{
    BATTERY_1 = 0,
    BATTERY_2,
    BATTERY_3,
    BATTERY_COUNT,

    BATTERY_LEFT = BATTERY_1,
    BATTERY_MIDDLE = BATTERY_2,
    BATTERY_RIGHT = BATTERY_3,
    BATTERY_NONE = -1
}

public class PlayerBatteryManager : MonoBehaviour
{
    private PlayerBattery[] _batteries;
    private List<PlayerMissile> _missilesAloft;


    // Start is called before the first frame update
    void Awake()
    {
        _missilesAloft = new List<PlayerMissile>();

        PlayerMissile.OnHitTarget += PlayerMissile_OnHitTarget;
    }


    private void Start()
    {
        _batteries = GameObject.FindObjectOfType<PlayerBattery>();

        
    }
    // Update is called once per frame
    void MouseClickHandler(MouseClick click)
    {
        
    }
}
