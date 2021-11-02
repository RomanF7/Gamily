using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoNive1Noche : MonoBehaviour
{
    [SerializeField]
    private Canvas canvasDialogo;
    [SerializeField]
    private Image cabeza;
    [SerializeField]
    private Sprite caraPer, caraPoli;
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private GameObject transicionNivel;

    private void Awake()
    {
        transicionNivel.GetComponent<Animator>().Play("TransicionEntrar");
    }

    public static bool movimientoPolicia;

    private int click = 25;
    private bool antesDelPuente = false;

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
            case 26 when antesDelPuente == true:
                canvasDialogo.enabled = false;
                MenuPausa.enPausa = false;
                break;
            case 27:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 28:
                canvasDialogo.enabled = false;
                MenuPausa.enPausa = false;
                movimientoPolicia = true;
                Doctor.visitaAlDoctor = true;
                click = 29;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AntesDelPuente" && click == 25)
        {
            canvasDialogo.transform.position = new Vector3(transform.position.x, 2, 0);
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            canvasDialogo.enabled = true;
            MenuPausa.enPausa = true;
            antesDelPuente = true;
        }
        else if (collision.gameObject.tag == "DespuesDelPuente" && click == 26)
        {
            canvasDialogo.transform.position = new Vector3(transform.position.x, 2, 0);
            antesDelPuente = false;
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            canvasDialogo.enabled = true;
            MenuPausa.enPausa = true;
        }
    }

}
