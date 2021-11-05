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

    private int click = 71;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FinalNv2" && click == 71)
        {
            cara.enabled = true;
            cara.sprite = carasPersonajes[0];
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
        }
    }
    private void Update()
    {

    }
}
