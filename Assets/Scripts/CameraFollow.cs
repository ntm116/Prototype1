using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject vehicle;

    [SerializeField]
    private Vector3 offset = Vector3.one;

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        transform.position = vehicle.transform.position - offset;
    }
}
