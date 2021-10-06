using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasto : MonoBehaviour
{
    public Transform pasto;
    private Vector3 posicion;

    private void Start()
    {
        posicion.y = -1.3f;
        posicion.z = 1;
    }
    private void LateUpdate()
    {
        posicion.x = transform.position.x;
        pasto.position = posicion;
    }
}
