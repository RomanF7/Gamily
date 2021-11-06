using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoFinal : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject efectoTransicion;
    public Image cara;
    public Sprite caraAxel, caraDoctor, caraMadre;

    private int click = 84;

    private void Start()
    {
        if (click == 84)
        {
            cara.sprite = caraDoctor;
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
            dialogo.enabled = true;
            MenuPausa.enPausa = true;
        }
    }
    private void Awake()
    {
        efectoTransicion.GetComponent<Animator>().Play("TransicionEntrar");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }
        switch (click)
        {
            case 86:
            case 88:
            case 89:
            case 91:
            case 94:
            case 97:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = caraDoctor;
                break;
            case 85:
            case 87:
            case 90:
            case 93:
            case 95:
            case 96:
            case 98:
            case 99:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = caraAxel;
                break;
            case 92:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = caraMadre;
                break;
            case 100:
                MenuPausa.enPausa = false;
                dialogo.enabled = false;
                efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
                break;
        }
        if (click >= 100)
            efectoTransicion.GetComponent<Animator>().Play("TransicionSalir");
    }
}
