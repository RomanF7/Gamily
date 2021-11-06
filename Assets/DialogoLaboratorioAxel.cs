using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoLaboratorioAxel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas canvasDialogo, canvasAviso;
    [SerializeField]
    private SpriteRenderer MedicinaRojaHUD;
    [SerializeField]
    private Image cabeza;
    [SerializeField]
    private SpriteRenderer flecha;

    private int click = 20;

    private void Update()
    {
        if (MedicinaRojaHUD.isVisible)
        {
            Dialogo();
        }
    }
    private void Dialogo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            click++;
        }
        if (Input.GetKeyDown(KeyCode.F) && click != 23)
        {
            click = 23;
        }
        switch (click)
        {
            case 0:
                MenuPausa.enPausa = false;
                canvasDialogo.enabled = false;
                canvasAviso.enabled = true;
                break;
            case 20:
                cabeza.enabled = true;
                MenuPausa.enPausa = true;
                canvasDialogo.enabled = true;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 21:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 22:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                if (LenguajesOpciones.enIngles)
                {
                    canvasAviso.GetComponentInChildren<TMP_Text>().SetText("Use the medicine with F.");
                }
                else
                {
                    canvasAviso.GetComponentInChildren<TMP_Text>().SetText("Usa la medicina con F.");
                }
                click = 0;
                break;
            case 23:
                canvasAviso.enabled = false;
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                canvasDialogo.enabled = true;
                break;
            case 24:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                break;
            case 25:
                flecha.enabled = true;
                MenuPausa.enPausa = false;
                canvasDialogo.enabled = false;
                break;
        }
    }
}
