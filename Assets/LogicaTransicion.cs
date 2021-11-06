using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaTransicion : MonoBehaviour
{
    public void CargarEscena()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Casa":
                SceneManager.LoadScene("Nivel1");
                break;
            case "Nivel1 (Noche)":
                SceneManager.LoadScene("Casa2");
                break;
            case "Casa2":
                SceneManager.LoadScene("CasaInicioNv2");
                break;
            case "Nivel2":
                SceneManager.LoadScene("Acto3");
                break;
            case "Nivel1":
                SceneManager.LoadScene("Laboratorio");
                break;
            case "Laboratorio":
                SceneManager.LoadScene("Nivel1 (Noche)");
                break;
            case "Acto3":
                SceneManager.LoadScene("End");
                break;
            case "End":
                SceneManager.LoadScene("Creditos");
                break;
            case "CasaInicioNv2":
                SceneManager.LoadScene("LabNv2");
                break;
            case "LabNv2":
                SceneManager.LoadScene("LabMedNv2");
                break;
        }
    }
}
