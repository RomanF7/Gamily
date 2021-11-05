using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoComienzoNv2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    public Image cara;
    public Sprite[] carasPersonajes = new Sprite[4];

    private int click = 50;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                click++;
            }
            switch (click)
            {
                case 50:
                    cara.enabled = true;
                    cara.sprite = carasPersonajes[0];
                    dialogo.enabled = true;
                    MenuPausa.enPausa = true;
                    click++;
                    break;
                case 51:
                    DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                    break;
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
                    Destroy(gameObject);
                    break;
            }
        }
    }
}