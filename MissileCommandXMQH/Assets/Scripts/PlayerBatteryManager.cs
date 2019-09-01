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
    public PlayerBattery[] _batteries;
    private List<PlayerMissile> _missilesAloft;

    // Start is called before the first frame update
    void Awake()
    {
        _missilesAloft = new List<PlayerMissile>();

        PlayerMissile.OnHitTarget += PlayerMissile_OnHitTarget;
    }

    private void Start()
    {
        _batteries = GameObject.FindObjectsOfType<PlayerBattery>();

        InputManager.onMouseClicked += MouseClickHandler;
    }
    void MouseClickHandler(MouseClick click)
    {
        PlayerBatteryId batteryId = PlayerBatteryId.BATTERY_NONE;

        switch(click.button)
        {
            case MouseButtons.LEFT:
                batteryId = PlayerBatteryId.BATTERY_LEFT;
                break;
            case MouseButtons.MIDDLE:
                batteryId = PlayerBatteryId.BATTERY_MIDDLE;
                break;
            case MouseButtons.RIGHT:
                batteryId = PlayerBatteryId.BATTERY_RIGHT;
                break;
        }

        FireMissileAndTrack(batteryId, click.worldPoint);
    }

    void FireMissileAndTrack(PlayerBatteryId batteryId, Vector2 target)
    {
        PlayerBattery battery = _batteries[(int)batteryId];

        PlayerMissile missile = battery.FireMissileAt(target, battery.gameObject.transform.position);

        if (missile != null) _missilesAloft.Add(missile);
    }

    private void PlayerMissile_OnHitTarget(PlayerMissile missile)
    {
        _missilesAloft.Remove(missile);
    }

    public int MissileCount
    {
        get { return _missilesAloft.Count; }
    }

    public int BatteryCount
    {
        get { return _batteries.Length; }
    }
}
