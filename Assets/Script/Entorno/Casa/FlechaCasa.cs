using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlechaCasa : MonoBehaviour
{
    [SerializeField]
    private GameObject efectoTransicion;

    private void OnTriggerStay2D(Collider2D collision)
    {
        efectoTransicion.SetActive(true);
        efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
    }
}
