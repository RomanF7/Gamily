using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabonActo3 : MonoBehaviour
{
    public GameObject efectoTransicion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
        }
    }
}
