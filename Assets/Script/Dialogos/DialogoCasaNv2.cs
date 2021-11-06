using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoCasaNv2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject efectoTransicion;
    public Image cara;
    public Sprite caraAxel;

    private int click = 35;

    private void Awake()
    {
        efectoTransicion.GetComponent<Animator>().Play("TransicionEntrar");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DialogoCasaNv2" && click == 35)
        {
            cara.sprite = caraAxel;
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }
        if (click == 36)
        {
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
        }
        else if (click >= 37)
        {
            MenuPausa.enPausa = false;
            dialogo.enabled = false;
            efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
        }
    }
}
