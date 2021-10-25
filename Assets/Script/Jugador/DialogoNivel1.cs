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
    private GameObject folleto, efectoDialogo, efectoTransicion;
    private bool devueltaACAsa, mostrarFolleto, recordatorioPlata;
    private int click = 2;

    private void Awake()
    {
        efectoTransicion.GetComponent<Animator>().Play("TransicionEntrar");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RecuerdoPlata" && click == 2)
        {
            efectoDialogo.SetActive(true);
            efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
            DialogoPorDefecto.intancia.Traducir(click + "", textoDialogo);
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
            devueltaACAsa = true;
            recordatorioPlata = true;
        }

        if (collision.gameObject.tag == "Folleto" && click == 4)
        {
            efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
            dialogo.transform.position = new Vector3(5, 2, 0);
            DialogoPorDefecto.intancia.Traducir(click + "", textoDialogo);
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
            case 3:
                DialogoPorDefecto.intancia.Traducir(click + "", textoDialogo);
                break;
            case 4:
                if (recordatorioPlata == true)
                {
                    efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
                    dialogo.enabled = false;
                    MenuPausa.enPausa = false;
                    recordatorioPlata = false;
                }
                break;
            case 5:
                if (mostrarFolleto == true)
                {
                    dialogo.enabled = false;
                    folleto.transform.localScale = new Vector3(2, 2, 2);
                    folleto.transform.position = new Vector3(5, -1, -20);
                }

                break;
            case 6:
                folleto.SetActive(false);
                DialogoPorDefecto.intancia.Traducir(click + "", textoDialogo);
                dialogo.enabled = true;
                break;
            case 7:
                efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
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
