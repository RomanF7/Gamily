using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoNivel1 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject folleto, efectoTransicion;
    private bool devueltaACAsa, mostrarFolleto, recordatorioPlata;
    private int click = 7;

    private void Awake()
    {
        efectoTransicion.GetComponent<Animator>().Play("TransicionEntrar");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RecuerdoPlata" && click == 7)
        {
           // efectoDialogo.SetActive(true);
           // efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
            devueltaACAsa = true;
            recordatorioPlata = true;
        }

        if (collision.gameObject.tag == "Folleto" && click == 9)
        {
           // efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
            dialogo.transform.position = new Vector3(47.64f, 2, 0);
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            MenuPausa.enPausa = true;
            dialogo.enabled = true;
            mostrarFolleto = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }
        //Debug.Log(click);
        switch (click)
        {
            case 8:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 9 when recordatorioPlata == true:
                    //efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
                    dialogo.enabled = false;
                    MenuPausa.enPausa = false;
                    recordatorioPlata = false;
                break;
            case 10 when mostrarFolleto == true:
                    dialogo.enabled = false;
                    folleto.transform.localScale = new Vector3(2, 2, 2);
                    folleto.transform.position = new Vector3(47.64f, -1, -20);
                break;
            case 11:
                folleto.SetActive(false);
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                dialogo.enabled = true;
                break;
            case 12:
               // efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
                MenuPausa.enPausa = false;
                dialogo.enabled = false;
                break;
        }
        if (Vector2.Distance(transform.position, folleto.transform.position) < 4 && devueltaACAsa == true)
        {
            folleto.SetActive(true);
            devueltaACAsa = false;
        }
    }
}
