using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaTransicion : MonoBehaviour
{
    public void CargarScena()
    {
        if (Doctor.visitaAlDoctor == false)
        {
            SceneManager.LoadScene("Nivel1");
        }
        else if (SceneManager.GetActiveScene().name == "Nivel1 (Noche)" && Doctor.visitaAlDoctor == true)
        {
            SceneManager.LoadScene("Casa2");
        }
        else if (Doctor.visitaAlDoctor == true && SceneManager.GetActiveScene().name == "Casa2")
        {
            SceneManager.LoadScene("CasaInicioNv2");
        }

        if (EntrarLab.tocandoLab == true && SceneManager.GetActiveScene().name == "Nivel1")
        {
            SceneManager.LoadScene("Laboratorio");
        }
    }
}
