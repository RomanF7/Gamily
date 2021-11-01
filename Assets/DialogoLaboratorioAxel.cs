using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoLaboratorioAxel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas canvasDialogo, canvasAviso;
    [SerializeField]
    private SpriteRenderer jeringaRoja;
    [SerializeField]
    private Image cabeza;
    [SerializeField]
    private SpriteRenderer flecha;

    private int click = 20;

    private void Update()
    {
        if (jeringaRoja.isVisible)
        {
            Dialogo();
        }
    }
    private void Dialogo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }
        if (Input.GetKeyDown(KeyCode.F) && click != 23)
        {
            click = 23;
        }
        switch (click)
        {
            case 0:
                MenuPausa.enPausa = false;
                canvasDialogo.enabled = false;
                canvasAviso.enabled = true;
                break;
            case 20:
                cabeza.enabled = true;
                MenuPausa.enPausa = true;
                canvasDialogo.enabled = true;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 21:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 22:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                click = 0;
                break;
            case 23:
                canvasAviso.enabled = false;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                canvasDialogo.enabled = true;
                break;
            case 24:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 25:
                flecha.enabled = true;
                MenuPausa.enPausa = false;
                canvasDialogo.enabled = false;
                break;
        }
    }
}
