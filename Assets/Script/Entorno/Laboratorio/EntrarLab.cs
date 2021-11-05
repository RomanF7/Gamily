using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarLab : MonoBehaviour
{
    public static bool tocandoLab;

    [SerializeField]
    private GameObject efectoTransicion;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !DialogoNivel1.deVueltaACasa)
        {
            tocandoLab = true;
            efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
        }
    }

}
