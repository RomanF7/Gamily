using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarLab : MonoBehaviour
{

    [SerializeField]
    private GameObject efectoTransicion;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !DialogoNivel1.deVueltaACasa)
        {
            efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
        }
    }

}
