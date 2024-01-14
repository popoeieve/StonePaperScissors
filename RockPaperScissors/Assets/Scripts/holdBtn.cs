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
    private bool estaMantenido = false;
    private float tiempoInicioPulsacion;
    private float duracionClicLargo = 1.0f; // Duración en segundos para considerar un clic largo

    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Cuando se presiona el botón
        estaMantenido = true;
        tiempoInicioPulsacion = Time.time;

        // Realiza acciones adicionales al inicio del clic continuo aquí
        Debug.Log("Has comenzado a pulsar");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Cuando se levanta el botón
        estaMantenido = false;

        // Calcular la duración de la pulsación
        float duracionPulsacion = Time.time - tiempoInicioPulsacion;

        // Realizar acciones adicionales al final del clic continuo aquí
        if (duracionPulsacion < duracionClicLargo)
        {
            // Se considera un clic corto
            Debug.Log("Botón clicado (clic corto)");
        }
        else
        {
            // Se considera un clic largo
            Debug.Log("Botón clicado (clic largo)");
            PerkDescriptionPanel.SetActive(true);
        }
    }

    void Update()
    {
        // Si el botón está siendo mantenido continuamente
        if (estaMantenido)
        {
            // Realiza acciones continuas aquí (se ejecutará cada frame mientras el botón esté mantenido)
            Debug.Log("Botón mantenido");
        }
    }
}
