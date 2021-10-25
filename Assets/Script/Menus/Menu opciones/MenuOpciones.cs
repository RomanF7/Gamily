using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MenuOpciones : MonoBehaviour
{
    //Variables publicas
    public Button btn_predeterminado, btn_oK, btn_IrMenu;
    public Image cruz;
    public TMP_Dropdown subMenuDeResoluciones;
    public GameObject admin;

    private AudioSource audioSource;

    private void Update()
    {
        audioSource.volume = ControlAudio.volumen;
    }

    public void Start()
    {
        //Añadir Listeners
        btn_predeterminado.onClick.AddListener(BTN_PredeterminadoClick);
        btn_oK.onClick.AddListener(BTN_OKClick);
        btn_IrMenu.onClick.AddListener(BTN_IrMenu);
        audioSource = GetComponent<AudioSource>();
    }

    //OnClick
    public void BTN_PredeterminadoClick()
    {
        //Setea por defecto las opciones (Futuro)
    }
    public void BTN_OKClick()
    {
        TomarResolucion();
    }
    public void BTN_IrMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void TomarResolucion()
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
