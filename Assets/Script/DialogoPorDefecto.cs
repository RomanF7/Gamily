using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class DialogoPorDefecto : MonoBehaviour
{
    public static DialogoPorDefecto intancia;
    private string parafo;
    private string[] oracionESP, oracionING;



    private void Awake()
    {
        string[] datosING = File.ReadAllLines(Application.dataPath + "\\Idiomas\\ING.txt",System.Text.Encoding.UTF7);
        string[] datosESP = File.ReadAllLines(Application.dataPath + "\\Idiomas\\ESP.txt", System.Text.Encoding.UTF7);
        oracionESP = datosESP;
        oracionING = datosING;
        intancia = this;
    }

    public void Traducir(string index, TMP_Text text)
    {
        parafo = "";
        string aux = "";

        if (LenguajesOpciones.enIngles)
        {
            for (int i = 0; i < oracionING.Length; i++)
            {
                aux = "";
                char[] letras = oracionING[i].ToCharArray();
                for (int h = 0; h < letras.Length; h++)
                {
                    if (char.IsDigit(letras[h]))
                    {
                        aux = aux + letras[h];
                    }
                }
                if (aux == index)
                {
                    for (int j = 1; j < letras.Length; j++)
                    {
                        parafo = parafo + letras[j];
                        aux = "";
                    }
                    parafo = parafo + "\n";
                }
            }
            text.SetText(parafo);
        }
        else if (LenguajesOpciones.enIngles == false && text.enabled == true)
        {

            for (int i = 0; i < oracionESP.Length; i++)
            {
                aux = "";
                char[] letras = oracionESP[i].ToCharArray();

                    if (char.IsDigit(letras[0]))
                    {
                        aux = aux + letras[0];
                    }
                
                if (aux == index)
                {
                    for (int j = 1; j < letras.Length; j++)
                    {
                        parafo = parafo + letras[j];
                        aux = "";
                    }
                    
                    parafo = parafo + "\n";
                }
            }
            text.SetText(parafo);
        }
    }
}
