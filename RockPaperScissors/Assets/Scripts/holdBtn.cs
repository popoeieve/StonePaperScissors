using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class holdBtn : MonoBehaviour, IPointerDownHandler
{
    private float longClickTime = 0.7f;
    private GameObject panel;
    int currentPerkLevel;
    private Dictionary<string, string> nameList = new Dictionary<string, string>
    {
        {"Perk1-1","Beyond the limits"},
        {"Perk2-1","Exterminatus of Deities"},
        {"Perk2-2","Tenacity"},
        {"Perk3-1","Supremacy of the strongest"},
        {"Perk3-2","Exasperation"},
        {"Perk3-3","Unrivalled defense"},
        {"Perk3-4","The begining of a legacy"},
        {"Perk4-1","Exemplary concentration"},
        {"Perk4-2","Fall of the weak"},
        {"Perk4-3","Knight insight"},
        {"Perk4-4","Diligence unknown"},
        {"Perk5-1","RecklessHero"},
        {"Perk5-2","TheOne"}
    };
    private Dictionary<string, string> descriptionList = new Dictionary<string, string>
    {
        {"Perk1-1","*N daño de combo ++++++"},
        {"Perk2-1","xN de daño a dioses ++++++"},
        {"Perk2-2","45% + en counter atack   +++++"},
        {"Perk3-1","45% + en slash   +++"},
        {"Perk3-2","45% + de Daño en ataques pesados ++"},
        {"Perk3-3","20% defensa extra por nivel++++"},
        {"Perk3-4","15% en todas las stats"},
        {"Perk4-1","*NIVEL de PERK daño  después de bloquear efectivamente+++++"},
        {"Perk4-2","*N de daño a todos los monstruos que no sean dioses  +++++"},
        {"Perk4-3","10% + de Exp y Oro+++++"},
        {"Perk4-4","20% de stats más al pasar de fase++++"},
        {"Perk5-1"," …+++++"},
        {"Perk5-2","No se sabe todavia"}
    };
    private Dictionary<string, string> imageList = new Dictionary<string, string>
    {
        {"Perk1-1","111"},
        {"Perk2-1","adios"},
        {"Perk2-2","adios"},
        {"Perk3-1","adios"},
        {"Perk3-2","adios"},
        {"Perk3-3","adios"},
        {"Perk3-4","adios"},
        {"Perk4-1","adios"},
        {"Perk4-2","adios"},
        {"Perk4-3","adios"},
        {"Perk4-4","adios"},
        {"Perk5-1","adios"},
        {"Perk5-2","adios"}
    };

    void Start()
    {
        panel = GameObject.Find("Canvas/PerkPanel/DescriptionPerkPanel");

        if (panel != null)
        {
            Debug.Log("Panel found");
        }
        else
        {
            Debug.LogError("Panel not found");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Has comenzado a pulsar");
        Button boton = GetComponent<Button>();
        TextMeshProUGUI textoDelBoton = boton.GetComponentInChildren<TextMeshProUGUI>();
        currentPerkLevel = int.Parse(textoDelBoton.text);
        Debug.Log("El nivel de la perk al iniciar la pulsación es de "+currentPerkLevel);
        StartCoroutine(LongClick());
    }

    IEnumerator LongClick()
    {
        yield return new WaitForSeconds(longClickTime);

        if (Input.GetMouseButton(0))
        { 
            Debug.Log("Botón clicado (clic largo)");
            panel.SetActive(true);
            Transform mask = panel.transform.GetChild(0);
            Transform image = mask.transform.GetChild(0);
            Transform segundoHijo = panel.transform.GetChild(1);
            Transform tercerHijo = panel.transform.GetChild(2);
            Image compImage = image.GetComponent<Image>();
            TextMeshProUGUI textoMesh2 = segundoHijo.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI textoMesh3 = tercerHijo.GetComponent<TextMeshProUGUI>();
            string nameBtn = gameObject.name;
            compImage.sprite = Resources.Load<Sprite>(imageList[nameBtn]);
            textoMesh2.text = nameList[nameBtn];
            textoMesh3.text = descriptionList[nameBtn];
            StartCoroutine(ReformatPerkCount());
        }
        else
        {
            Debug.Log("Botón clicado (clic corto)");
        }
    }

    // Este método se llama para acceder al componente TextMeshProUGUI del botón
    IEnumerator ReformatPerkCount()
    {
        Debug.Log("Empieza el retraso");
        yield return new WaitForSeconds(0.7f);
        Debug.Log("Termina el retraso");
        // Obtén el componente Button del mismo GameObject al que se ha asignado este script
        Button boton = GetComponent<Button>();

        // Verifica si se encontró el componente Button
        if (boton != null)
        {
            // Accede al componente TextMeshProUGUI del botón
            TextMeshProUGUI buttonText = boton.GetComponentInChildren<TextMeshProUGUI>();

            // Verifica si se encontró el componente TextMeshProUGUI y si el texto del boton sigue como en su estado original
            if (buttonText != null && buttonText.text!=currentPerkLevel.ToString())
            {
                // Haz algo con el componente TextMeshProUGUI, por ejemplo, accede al texto                
                PlayerPrefs.SetInt("ExtraPerkPoints", PlayerPrefs.GetInt("ExtraPerkPoints", 0) + 1);
                buttonText.text = currentPerkLevel.ToString();
                GameObject perkPointsAvaiable= GameObject.Find("Canvas/PerkPanel/perkPoints");
                TextMeshProUGUI perkText = perkPointsAvaiable.GetComponent<TextMeshProUGUI>();
                perkText.text = PlayerPrefs.GetInt("ExtraPerkPoints", 0).ToString();
                Debug.Log("El nivel del perk al finalizar la pulsación es : "+buttonText.text);
            }
            else
            {
                Debug.Log("No se encontró el componente TextMeshProUGUI en el botón o quedan 0 puntos o no ha cambiado el valor");
                
            }
        }
        else
        {
            Debug.LogError("No se encontró el componente Button en el GameObject.");
        }
    }

    void Update()
    {

    }
}
