using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoLabNv2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoDialogo;
    [SerializeField]
    private Canvas dialogo;
    [SerializeField]
    private GameObject efectoDialogo;
    public Image cara;
    public Sprite caraAxel, caraDoctor;

    private int click = 37;

    private void Start()
    {
        if (click == 37)
        {
            efectoDialogo.SetActive(true);
            efectoDialogo.GetComponent<Animator>().Play("EntrandoBarras");
            cara.sprite = caraDoctor;
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
        switch (click)
        {
            case 38:
            case 39:
            case 40:
            case 42:
            case 44:
            case 46:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = caraDoctor;
                break;
            case 41:
            case 43:
            case 45:
                DialogoPorDefecto.instancia.Traducir(click + "", textoDialogo);
                cara.sprite = caraAxel;
                break;
            case 47:
                MenuPausa.enPausa = false;
                dialogo.enabled = false;
                efectoDialogo.GetComponent<Animator>().Play("SalirBarras");
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("LabMedNv2");
                break;
        }
        if (click >= 48)
            UnityEngine.SceneManagement.SceneManager.LoadScene("LabMedNv2");
    }
}
