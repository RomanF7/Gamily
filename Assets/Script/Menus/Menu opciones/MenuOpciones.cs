using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MenuOpciones : MonoBehaviour
{

    private bool modoSincronizacion;

    //Variables publicas
    public Button btn_predeterminado, btn_oK, btn_irMenu;
    public Image crucecita;
    public TMP_Dropdown subMenuDeResoluciones;
    public GameObject admin;

    void Start()
    {
        modoSincronizacion = false;

        //Añadir Listeners
        btn_predeterminado.onClick.AddListener(BTN_predeterminadoClick);
        btn_oK.onClick.AddListener(BTN_oKClick);
        btn_irMenu.onClick.AddListener(BTN_irMenu);
    }

    //OnClick
    void BTN_predeterminadoClick()
    {
        //Setea por defecto las opciones (Futuro)
    }

    void BTN_oKClick()
    {
        TomarResolucion();
    }

    void BTN_sincronizacionVer()
    {
        if (modoSincronizacion == false)
        {
            modoSincronizacion = true;
            crucecita.enabled = true;
        }
        else if (modoSincronizacion == true)
        {
            modoSincronizacion = false;
            crucecita.enabled = false;
        }
    }

    void BTN_irMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    void TomarResolucion()
    {
        bool pasar = false;
        int posicion = subMenuDeResoluciones.value,ancho, largo;
        String anchoST = "", largoST = "", resolucion = subMenuDeResoluciones.options[posicion].text;

        for (int i = 0; i < resolucion.Length; i++)
        {
            char aux = resolucion[i];
            Debug.Log(aux);
            if (aux == 'x')
            {
                pasar = true;
            }
            else
            {
                if (pasar == true)
                {
                    largoST = largoST + aux;
                }
                else if (pasar == false)
                {
                    anchoST = anchoST + aux;
                }
                
            }
        }
        ancho = int.Parse(anchoST);
        largo = int.Parse(largoST);
        Debug.Log(ancho + " " + largo);
        Screen.SetResolution(ancho, largo,Screen.fullScreen);

    }
}
