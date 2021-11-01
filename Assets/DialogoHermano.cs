using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoHermano : MonoBehaviour
{

    [SerializeField]
    private Canvas canvasDialogo;
    [SerializeField]
    private Image cabeza;
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Sprite caraPer, caraHer;

    private int click = 31;

    void Update()
    {
        if (Madre.terminaDialogomadre)
        {
            DialogoRegresoDeCasa();
        }
    }

    private void DialogoRegresoDeCasa()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }

        switch (click)
        {
            case 31:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cabeza.sprite = caraHer;
                break;
            case 32:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cabeza.sprite = caraPer;
                break;
            case 33:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cabeza.sprite = caraHer;
                break;
            case 34:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cabeza.sprite = caraPer;
                break;
        }
    }
}
