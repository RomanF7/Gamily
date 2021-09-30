using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuConfirmacionSalir : MonoBehaviour
{
    //Variables publicas
    public Button btn_continuar, btn_salir;

    //Variables privadas
    private Canvas canvasMenuConfirmacionSalir;
    private void Start()
    {
        //Añadir Listenners
        btn_continuar.onClick.AddListener(BTN_ContinuarClick);
        btn_salir.onClick.AddListener(BTN_SalirClick);

        //Tomar componente
        canvasMenuConfirmacionSalir = GetComponent<Canvas>();
    }

    //OnCLick
    public void BTN_ContinuarClick()
    {
        canvasMenuConfirmacionSalir.enabled = false;
    }

    public void BTN_SalirClick()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
