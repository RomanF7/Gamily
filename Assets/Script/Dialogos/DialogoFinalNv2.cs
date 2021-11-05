using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoFinalNv2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject efectoDialogo;
    public Image cara;
    public Sprite[] carasPersonajes = new Sprite[4];

    private int click = 71;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && click == 71)
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
            case 72:
            case 73:
            case 75:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[1];
                break;
            case 74:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = carasPersonajes[0];
                break;
            case 76:
                MenuPausa.enPausa = false;
                dialogo.enabled = false;
                efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
                Destroy(gameObject);
                break;
        }
    }
}
