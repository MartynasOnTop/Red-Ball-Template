using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothnes;

    private void Update()
    {
        if (target == null) return;

        var pos = target.position;
        pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, pos, smoothnes * Time.deltaTime);
    }
}
