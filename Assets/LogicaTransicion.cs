using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaTransicion : MonoBehaviour
{
    public void CargarEscena()
    {
        if (SceneManager.GetActiveScene().name == "Casa")
        {
            SceneManager.LoadScene("Nivel1");
        }
        else if (SceneManager.GetActiveScene().name == "Nivel1 (Noche)")
        {
            SceneManager.LoadScene("Casa2");
        }
        else if (SceneManager.GetActiveScene().name == "Casa2")
        {
            SceneManager.LoadScene("CasaInicioNv2");
        }
        else if (SceneManager.GetActiveScene().name == "Nivel2")
        {
            SceneManager.LoadScene("Acto3");
        }

        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            SceneManager.LoadScene("Laboratorio");
        }
    }
}
