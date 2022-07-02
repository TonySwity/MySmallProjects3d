using System;
using UnityEngine;

public class TestRayCast : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if ( Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point,Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f,Color.green);
        }

       
    }
}
