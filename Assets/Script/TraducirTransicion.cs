using TMPro;
using UnityEngine;

public class TraducirTransicion : MonoBehaviour
{
    private TMP_Text texto;
    private void Awake()
    {
        texto = GetComponent<TMP_Text>();
        if (LenguajesOpciones.enIngles)
        {
            texto.SetText("The next day...");
        }
        else
        {
            texto.SetText("Al día siguiente...");
        }
    }
}
