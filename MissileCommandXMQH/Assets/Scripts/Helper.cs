﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    protected static Vector2 mousePoint;
    protected static Camera cam;

    public static Vector2 MousePosToWorldVec()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
        mousePoint = Input.mousePosition;
        return (cam.ScreenToWorldPoint(mousePoint));
    }

    public static Quaternion GetLocalAngleBetweenVectors2(Vector2 v1, Vector2 v2)
    {
        Vector2 diff = (v2 - v1);
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        return (Quaternion.Euler(0f, 0f, rot_z));
    }
}
