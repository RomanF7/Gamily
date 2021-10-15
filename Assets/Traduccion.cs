using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Traduccion : MonoBehaviour
{
    public Text texto;
    private string textoAPasar;
    StreamReader enEspañol, enIngles;

    private void Awake()
    {
        enIngles = new StreamReader(Application.dataPath + "\\Idiomas\\ING.txt");
        enEspañol = new StreamReader(Application.dataPath + "\\Idiomas\\ESP.txt");
    }
    private void Start()
    {

        Traducir();
    }
    public void Traducir()
    {

        if (LenguajesOpciones.enIngles)
        {
            textoAPasar = enIngles.ReadLine();
            Debug.Log(textoAPasar);
            texto.text = textoAPasar;
        }
        else if (LenguajesOpciones.enIngles == false)
        {
            textoAPasar = enEspañol.ReadLine();
            Debug.Log(textoAPasar);
            texto.text = textoAPasar;
        }
    }
}
