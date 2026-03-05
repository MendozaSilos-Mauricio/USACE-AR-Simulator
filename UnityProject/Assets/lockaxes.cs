using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAxes : MonoBehaviour
{
    public bool lockY = true;
    public bool lockZ = false;

    public float minY = 0f;
    public float minZ = 0f;

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (lockY && pos.y < minY)
            pos.y = minY;

        if (lockZ && pos.z < minZ)
            pos.z = minZ;

        transform.position = pos;
    }
}