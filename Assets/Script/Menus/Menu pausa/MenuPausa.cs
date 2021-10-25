using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    //Variables publicas
    public Button btn_continuar, btn_menuPrincipal;
    public Canvas canvasConfirmacionSalir;
    public static MenuPausa instancia;

    //Variables privadas
    private Canvas canvasPausa;
    public static bool enPausa;

    private void Start()
    {
        //Añadir Listeners
        btn_continuar.onClick.AddListener(BTN_ContinuarClick);
        btn_menuPrincipal.onClick.AddListener(BTN_SalirClick);

        //Toman componente
        canvasPausa = GetComponent<Canvas>();
        instancia = this;
    }

    private void Update()
    {
        if(canvasPausa.enabled == true)
        {
            enPausa = true;
        }
    }

    //OnClick
    public void BTN_ContinuarClick()
    {
        canvasPausa.enabled = false;
        enPausa = false;
    }

    public void BTN_SalirClick()
    {
        canvasConfirmacionSalir.enabled = true;
    }
}
