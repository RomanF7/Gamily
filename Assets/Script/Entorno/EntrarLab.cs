using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarLab : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("el if funciona");
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Laboratorio");
        }
    }

}
