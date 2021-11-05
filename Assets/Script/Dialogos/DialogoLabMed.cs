using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoLabMed : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject efectoDialogo;
    public Image cara;
    public Sprite caraAxel;

    private int click = 47;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && click == 47)
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

        if (click == 48)
        {
            DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
        }
        else if (click >= 49)
        {
            MenuPausa.enPausa = false;
            dialogo.enabled = false;
            efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel2");
        }
    }
}

