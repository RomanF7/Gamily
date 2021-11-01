using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaFlecha : MonoBehaviour
{
    [SerializeField]
    private GameObject efectoTransicion;
    public static bool enContacto;
    private void OnTriggerStay2D(Collider2D collision)
    {
        enContacto = true;
        efectoTransicion.SetActive(true);
        efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
    }
}
