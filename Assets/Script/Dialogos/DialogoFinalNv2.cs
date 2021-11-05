using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoFinalNv2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    public Image cara;
    public Sprite[] carasPersonajes = new Sprite[4];

    private int click = 70;

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
                case 70:
                    cara.enabled = true;
                    cara.sprite = carasPersonajes[0];
                    dialogo.enabled = true;
                    MenuPausa.enPausa = true;
                    click++;
                    break;
                case 71:
                    DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                    break;
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
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
