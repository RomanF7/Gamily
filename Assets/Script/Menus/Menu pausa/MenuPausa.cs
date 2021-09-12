using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    //Variables publicas
    public Button btn_continuar, btn_menuPrincipal;
    public Canvas canvasConfirmacionSalir;

    //Variables privadas
    private Canvas canvasPausa;
    private bool enPausa;

    void Start()
    {
        //Añadir Listeners
        btn_continuar.onClick.AddListener(BTN_ContinuarClick);
        btn_menuPrincipal.onClick.AddListener(BTN_SalirClick);

        //Toman componente
        canvasPausa = GetComponent<Canvas>();
    }

    private void Update()
    {
        if(canvasPausa.enabled == true)
        {
            enPausa = true;
        }
        else
        {
            enPausa = false;
        }
    }

    //OnClick
    void BTN_ContinuarClick()
    {
        canvasPausa.enabled = false;
        enPausa = false;
    }

    void BTN_SalirClick()
    {
        canvasConfirmacionSalir.enabled = true;
    }

    //Getters
    public bool GetEnPausa()
    {
        return enPausa;
    }
}
