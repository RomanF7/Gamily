using System.IO;
using TMPro;
using UnityEngine;

public class DialogoPorDefecto : MonoBehaviour
{
    public static DialogoPorDefecto instancia;
    private string parrafo;
    private string[] oracionESP, oracionING;



    private void Awake()
    {
        string[] datosING = File.ReadAllLines(Application.dataPath + "\\Idiomas\\ING.txt", System.Text.Encoding.UTF7);
        string[] datosESP = File.ReadAllLines(Application.dataPath + "\\Idiomas\\ESP.txt", System.Text.Encoding.UTF7);
        oracionESP = datosESP;
        oracionING = datosING;
        instancia = this;
    }

    public void Traducir(string index, TMP_Text text)
    {
        parrafo = "";
        string aux = "";
        if (index.Length == 1)
            index = "0" + index;
        if (LenguajesOpciones.enIngles && text.enabled == true)
        {
            for (int i = 0; i < oracionING.Length; i++)
            {
                aux = "";
                char[] letras = oracionING[i].ToCharArray();

                if (char.IsDigit(letras[0]) && char.IsDigit(letras[1]))
                {
                    aux = aux + letras[0] + letras[1];
                }

                if (aux == index)
                {
                    for (int j = 2; j < letras.Length; j++)
                    {
                        parrafo = parrafo + letras[j];
                        aux = "";
                    }
                    parrafo = parrafo + "\n";
                }
            }
            text.SetText(parrafo);
        }
        else if (LenguajesOpciones.enIngles == false && text.enabled == true)
        {

            for (int i = 0; i < oracionESP.Length; i++)
            {
                aux = "";
                char[] letras = oracionESP[i].ToCharArray();

                if (char.IsDigit(letras[0]) && char.IsDigit(letras[1]))
                {
                    aux = aux + letras[0] + letras[1];
                }

                if (aux == index)
                {
                    for (int j = 2; j < letras.Length; j++)
                    {
                        parrafo = parrafo + letras[j];
                        aux = "";
                    }

                    parrafo = parrafo + "\n";
                }
            }
            text.SetText(parrafo);
        }
    }
}
