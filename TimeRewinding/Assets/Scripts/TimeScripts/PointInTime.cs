using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime 
{
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 velo;
    public bool active;


    public PointInTime()
    {

    }

    public PointInTime(Vector3 position, Quaternion rotation, bool act)
    {
        pos = position;
        rot = rotation;
        active = act;
    }

    public PointInTime(Vector3 position, Quaternion rotation, Vector3 veloc,  bool act)
    {
        pos = position;
        rot = rotation;
        velo = veloc;
        active = act;
    }

    public bool isSame(PointInTime other)
    {
        if (pos == other.pos && rot == other.rot && velo == other.velo && active == other.active)
            return true;
        else
            return false;
    }
}
