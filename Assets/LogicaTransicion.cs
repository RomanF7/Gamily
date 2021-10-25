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
        else if (SceneManager.GetActiveScene().name == "Nivel1 (Noche)")
        {
            SceneManager.LoadScene("Casa2");
        }
        else if (Doctor.visitaAlDoctor == true)
        {
            SceneManager.LoadScene("Nivel1 (Noche)");
        }

        if (EntrarLab.tocandoLab == true)
        {
            SceneManager.LoadScene("Laboratorio");
        }
    }
}
