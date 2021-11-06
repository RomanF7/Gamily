using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
   //Notas n°0: Dia 253, ya estoy cansado de reprogramar, me quejare para que me paguen.

    //Variables publicas
    public Button btn_nuevaPartida, btn_continuarPartida, btn_opciones, btn_salir;
    public Canvas menuPrincipal;

    //Variables privadas
    private bool empezar, enIngles;
    private AudioSource audioSource;
    private void Update()
    {
        audioSource.volume = ControlAudio.volumen;
    }

    private void Start()
    {
        //Añair a los botones Listeners
        btn_opciones.onClick.AddListener(BTN_OpcionesClick);
        btn_salir.onClick.AddListener(BTN_SalirClick);
        btn_nuevaPartida.onClick.AddListener(BTN_NuevaPartidaClick);
        btn_continuarPartida.onClick.AddListener(BTN_ContinuarPartidaClick);
        audioSource = GetComponent<AudioSource>();
    }

    //OnClick
    public void BTN_NuevaPartidaClick()
    {
        empezar = true;
        SceneManager.LoadScene("Casa");

    }

    public void BTN_OpcionesClick()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void BTN_SalirClick()
    {
        Application.Quit();
    }

    public void BTN_ContinuarPartidaClick()
    {
        GuardarCargarDatos.instancia.Cargar();
    }

    //Getters
    public bool GetEmpezar()
    {
        return empezar;
    }
    public bool GetEnIngles()
    {
        return enIngles;
    }
}

