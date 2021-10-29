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
    private Canvas canvasDialogo;
    [SerializeField]
    private SpriteRenderer jeringaRoja;
    [SerializeField]
    private Image cabeza;

    private int click = 20;

    private void Update()
    {
        Debug.Log(jeringaRoja.isVisible);
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

        switch (click)
        {
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
                break;
            case 23:
                MenuPausa.enPausa = false;
                canvasDialogo.enabled = false;
                break;
        }
    }
}
