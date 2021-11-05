using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoComienzoNv2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject efectoDialogo;
    public Image cara;
    public Sprite[] carasPersonajes = new Sprite[4];

    private int click = 51;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && click == 51)
        {
            efectoDialogo.SetActive(true);
            efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
            cara.sprite = carasPersonajes[0];
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
        }
    }
    private void Update()
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
                efectoDialogo.GetComponent<Animator>().Play("SaliendoBarras");
                Destroy(gameObject);
                break;
        }
    }
}
