using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Transform;
    public Vector3 offset = Vector3.zero;

    void Start()
    {
        offset = transform.position - Transform.position;
    }

    void Update()
    {
        Vector3 lastPosition = Transform.position + offset;

        transform.position = lastPosition;
    }
}
