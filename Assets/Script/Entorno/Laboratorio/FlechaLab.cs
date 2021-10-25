using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlechaLab : MonoBehaviour
{
    [SerializeField]
    private GameObject efectoTransicion;

    private void Awake()
    {
        efectoTransicion.GetComponent<Animator>().Play("TransicionEntrar");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Doctor.visitaAlDoctor == true)
        {
            efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
        }
    }
}
