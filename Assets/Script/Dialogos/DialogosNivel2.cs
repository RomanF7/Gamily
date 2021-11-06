using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogosNivel2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject efectoTransicion;
    public Image cara;
    [SerializeField]
    private Sprite[] carasPersonajes = new Sprite[2];

    private int click = 51;
    private bool colisionInicio = false;

    private void Awake()
    {
        efectoTransicion.GetComponent<Animator>().Play("TransicionEntrar");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ComienzoNv2")
        {
            click = 51;
            colisionInicio = true;
            cara.enabled = true;
            cara.sprite = carasPersonajes[0];
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
        }
        else if (collision.gameObject.tag == "FinalNv2")
        {
            click = 71;
            colisionInicio = false;
            cara.enabled = true;
            cara.sprite = carasPersonajes[0];
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
        }
    }
    private void Update()
    {
        if (colisionInicio)
        {
            DialogoInicial();
        }
        else
        {
            DialogoFinal();
        }
    }

    private void DialogoInicial()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }
        switch (click)
        {
            case 52:
            case 54:
            case 56:
            case 57:
            case 59:
            case 60:
            case 62:
            case 64:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[1];
                break;
            case 53:
            case 55:
            case 58:
            case 61:
            case 63:
            case 65:
            case 66:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[0];
                break;
            case 67:
                cara.enabled = false;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 68:
                MenuPausa.enPausa = false;
                dialogo.enabled = false;
                break;
        }
    }

    private void DialogoFinal()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }
        switch (click)
        {
            case 72:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[1];
                break;
            case 73:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[1];
                break;
            case 74:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[0];
                break;
            case 75:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[1];
                break;
            case 76:
                MenuPausa.enPausa = false;
                dialogo.enabled = false;
                break;
        }
    }
}