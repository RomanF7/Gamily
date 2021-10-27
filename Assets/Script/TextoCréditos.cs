using System.Collections;
using UnityEngine;
using TMPro;




public class TextoCréditos : MonoBehaviour
{

    private string[] creditos = new string[6];

    private TMP_Text TextoTMP;


    void Awake()
    {
        TextoTMP = GetComponent<TMP_Text>();
        creditos[0] = "- Time is Money -\nDesarrollado por Gamily";
        creditos[1] = "Coordinador, Programación:\nRomán Ferreira";
        creditos[2] = "Subcoordinador, Supervisión:\nMatías Barretto";
        creditos[3] = "Arte, Sonido, Historia:\nIgnacio Rivero";
        creditos[4] = "Análisis y Diseño:\nFacundo Cor";
        creditos[5] = "Administración de Negocios Digitales:\nGonzalo Ferrando";
        TextoTMP.text = creditos[0];
    }

    [System.Obsolete]
    IEnumerator Start()
    {

        for (int i=0; i<creditos.Length; i++) 
        {
            int caracteresVisiblesActual = 0;
            int contador = 0;
            TextoTMP.text = creditos[i];

            // ForceMeshUpdate, para que la información del mesh sea válida.
            TextoTMP.ForceMeshUpdate();

            int caracteresVisiblesTotal = TextoTMP.textInfo.characterCount; // Obtener caracteres visibles del texto original.
            
            while (!(caracteresVisiblesActual >= caracteresVisiblesTotal))
            {
                caracteresVisiblesActual = contador % (caracteresVisiblesTotal + 1);
                TextoTMP.maxVisibleCharacters = caracteresVisiblesActual; // Obtener cuántos caracteres más se deben mostrar.
                contador += 1;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1.5f);
        }
        Destroy(TextoTMP);

    }

}
