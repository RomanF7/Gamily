using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogosDeDoctor : MonoBehaviour
{

    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas canvasDialogo;
    [SerializeField]
    private Image cabeza;
    [SerializeField]
    private Sprite caraPer, caraDoc;
    private int click = 12;

    private void Update()
    {
        Dialogo();
    }
    private void Dialogo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }

        switch (click)
        {
            case 12:
                MenuPausa.enPausa = true;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                canvasDialogo.enabled = true;
                break;
            case 13:
                cabeza.sprite = caraDoc;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 14:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 15:
                cabeza.sprite = caraPer;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 16:
                cabeza.sprite = caraDoc;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 17:
                cabeza.sprite = caraPer;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 18:
                cabeza.sprite = caraDoc;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 19:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 20:
                cabeza.enabled = false;
                cabeza.sprite = caraPer; 
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                canvasDialogo.enabled = false;
                if (Doctor.visitaAlDoctor == false)
                {
                    Doctor.visitaAlDoctor = true;
                    Doctor.instancia.cronometro[0] = Time.time + 0.5f;
                    Doctor.instancia.cronometro[1] = Time.time + 1.5f;
                }
                if (Time.time >= Doctor.instancia.cronometro[0] && Doctor.instancia.cronometro[0] != 0)
                {
                    Doctor.instancia.Movimiento();
                }
                MenuPausa.enPausa = false;
                break;
        }
    }
}
