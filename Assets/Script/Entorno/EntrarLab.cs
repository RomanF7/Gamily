using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarLab : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("ENTRASTE LPM, PERO FUNCIONA EL IF XD");
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Laboratorio");
        }
    }

}
