using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Madre : MonoBehaviour
{
    [SerializeField]
    private float movimiento;
    [SerializeField]
    private Canvas canvasDialogo;
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Sprite caraPer, caraMad;
    [SerializeField]
    private Transform axel;
    [SerializeField]
    private GameObject efectoDialogo;

    private float cronometro;
    private int click = 1;
    private Animator animator;
    private bool stop, distanciaCorrecta;
    private void Awake()
    {
        efectoDialogo.SetActive(true);
        efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
        stop = false;
        cronometro = 0;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time > cronometro && stop == false && Doctor.visitaAlDoctor == false)
        {
            cronometro = Time.time + 2.5f;
            stop = true;
            MenuPausa.enPausa = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
            click++;

        if (Time.time < cronometro)
        {
            transform.Translate(movimiento * Time.deltaTime, 0, 0);
            animator.Play("MadreCaminar");
        }
        else if (Time.time > cronometro && stop == false && Doctor.visitaAlDoctor == true)
        {
            transform.Translate(-movimiento * Time.deltaTime, 0, 0);
            animator.Play("MadreCaminar");
        }

        if (Vector2.Distance(transform.position, axel.position) < 3 && distanciaCorrecta == false)
        {
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            canvasDialogo.enabled = true;
            animator.enabled = false;
            distanciaCorrecta = true;
        }

        switch (click)
        {
            case 1:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 2: case 3: case 4:
            case 5: case 6:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 7:
                efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
                textoDialogo.enabled = false;
                canvasDialogo.enabled = false;
                MenuPausa.enPausa = false;
                break;
        }
    }
}
