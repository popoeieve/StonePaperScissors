using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class holdBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject PerkDescriptionPanel;
    private GameObject instantiatedPanel; // Referencia al panel instanciado
    private bool estaMantenido = false;
    private float tiempoInicioPulsacion;
    private float duracionClicLargo = 0.7f;

    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        estaMantenido = true;
        tiempoInicioPulsacion = Time.time;

        Debug.Log("Has comenzado a pulsar");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Cuando se levanta el bot�n
        estaMantenido = false;

        // Calcular la duraci�n de la pulsaci�n
        float duracionPulsacion = Time.time - tiempoInicioPulsacion;

        // Realizar acciones adicionales al final del clic continuo aqu�
        if (duracionPulsacion < duracionClicLargo)
        {
            // Se considera un clic corto
            Debug.Log("Bot�n clicado (clic corto)");
        }
        else
        {
            Debug.Log("Bot�n clicado (clic largo)");
            instantiatedPanel = Instantiate(PerkDescriptionPanel, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (estaMantenido)
        {
            Debug.Log("Bot�n mantenido");
        }
    }
}
