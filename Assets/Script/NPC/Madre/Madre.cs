using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Madre : MonoBehaviour
{
    public static bool terminaDialogomadre;

    [SerializeField]
    private float movimiento;
    [SerializeField]
    private Canvas canvasDialogo;
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Sprite caraPer, caraMad;
    [SerializeField]
    private Image cabeza;
    [SerializeField]
    private Transform axel;
    //[SerializeField]
    //private GameObject efectoDialogo;

    private int click;
    private Animator animator;
    private bool distanciaCorrecta;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Casa2")
        {
            Doctor.visitaAlDoctor = true;
        }

        if (Doctor.visitaAlDoctor)
        {
            click = 28;
        }
        else
        {
            click = 1;
        }
        // efectoDialogo.SetActive(true);
        // efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Doctor.visitaAlDoctor)
        {
            DialogoIntroductorio();
        }
        else
        {
            DialogoDeRegreso();
        }
    }

    private void DialogoIntroductorio()
    {

        if (Input.GetKeyDown(KeyCode.E))
            click++;

        if (distanciaCorrecta == false)
        {
            transform.Translate(movimiento * Time.deltaTime, 0, 0);
            animator.Play("MadreCaminar");
            MenuPausa.enPausa = true;
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
            case 2:
                cabeza.sprite = caraPer;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 3:
            case 4:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 5:
                cabeza.sprite = caraMad;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 6:
                cabeza.sprite = caraPer;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 7:
                // efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
                textoDialogo.enabled = false;
                canvasDialogo.enabled = false;
                MenuPausa.enPausa = false;
                break;
        }
    }

    private void DialogoDeRegreso()
    {
        if (Input.GetKeyDown(KeyCode.E))
            click++;

        if (distanciaCorrecta == false)
        {
            transform.Translate(-movimiento * Time.deltaTime, 0, 0);
            animator.Play("MadreCaminar");
            MenuPausa.enPausa = true;
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
            case 29:
                cabeza.sprite = caraMad;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 30:
                cabeza.sprite = caraPer;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                terminaDialogomadre = true;
                break;
        }
    }
}
