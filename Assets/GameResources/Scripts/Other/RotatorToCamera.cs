using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Поворачивает канвас к камере
/// </summary>
public class RotatorToCamera : MonoBehaviour
{
    private Transform target;

    private void Awake()
    {
        target = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(target);
    }
}
