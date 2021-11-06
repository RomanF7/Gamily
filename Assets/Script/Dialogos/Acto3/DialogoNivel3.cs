using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoNivel3 : MonoBehaviour
{
    [SerializeField]
    private Canvas canvasDialogo;
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private GameObject volverPunto, camara;


    public static int click = 76;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(click);
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
            case 77:
                MenuPausa.enPausa = false;
                canvasDialogo.enabled = false;
                Jefe.ataque2 = true;
                break;
            case 78:
                Jefe.ataque1 = true;
                break;
            case 79:
                Jefe.ataque3 = true;
                break;
            case 81:
                canvasDialogo.enabled = false;
                animator.SetBool("Jabon", true);
                MenuPausa.enPausa = true;
                transform.position = volverPunto.transform.position;
                camara.transform.position = transform.position;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InicioPeleaBoss" && click == 76)
        {
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            MenuPausa.enPausa = true;
            canvasDialogo.enabled = true;
        }
    }


}
