using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardarCargarDatos : MonoBehaviour
{
    public static GuardarCargarDatos intancia;
    public SpriteRenderer jeringaRojaHUD;

    private void Awake()
    {
        intancia = this;
    }
    public void Guardar()
    {
        InfoJugador jugador = new InfoJugador();
        jugador.posicion = intancia.transform.position;
        jugador.escena = SceneManager.GetActiveScene().name;

        Debug.Log(JsonUtility.ToJson(jugador));

        PlayerPrefs.DeleteKey("Guardado");
        PlayerPrefs.SetString("Guardado", JsonUtility.ToJson(jugador));
    }

    public void Cargar()
    {
        InfoJugador jugador = new InfoJugador();
        jugador = JsonUtility.FromJson<InfoJugador>(PlayerPrefs.GetString("Guardado"));
        if (jugador != null)
        {
            intancia.transform.position = jugador.posicion;
            SceneManager.LoadScene(jugador.escena);
        }
    }
}
[SerializeField]
public class InfoJugador
{
    public Vector3 posicion;
    public string escena;
}


