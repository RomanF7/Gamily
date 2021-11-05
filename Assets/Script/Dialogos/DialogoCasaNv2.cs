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
    private GameObject efectoDialogo;
    public Image cara;
    public Sprite caraAxel;

    private int click = 35;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DialogoCasaNv2" && click == 35)
        {
            efectoDialogo.SetActive(true);
            efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
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
            efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
            UnityEngine.SceneManagement.SceneManager.LoadScene("LabNv2");
        }
    }
}
