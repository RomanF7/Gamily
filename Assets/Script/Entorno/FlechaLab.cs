using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlechaLab : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && Doctor.visitaAlDoctor == true)
        {
            SceneManager.LoadScene("Nivel1 (Noche)");
        }
    }
}
