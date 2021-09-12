using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
   //Notas n°0: Dia 253, ya estoy cansado de reprogramar, me quejare para que me paguen.

    //Variables publicas
    public Button btn_nuevaPartida/*, continuarPartida*/, btn_opciones, btn_salir;
    public Canvas menuPrincipal;

    //Variables privadas
    private bool empezar, enIngles;

    private void Start()
    {
        //Añair a los botones Listeners
        btn_opciones.onClick.AddListener(BTN_OpcionesClick);
        btn_salir.onClick.AddListener(BTN_SalirClick);
        btn_nuevaPartida.onClick.AddListener(BTN_NuevaPartidaClick);
    }

    //OnClick
    void BTN_NuevaPartidaClick()
    {
        empezar = true;
        SceneManager.LoadScene("Nivel1");

    }

    void BTN_OpcionesClick()
    {
        SceneManager.LoadScene("Opciones");
    }

    void BTN_SalirClick()
    {
        Application.Quit();
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

