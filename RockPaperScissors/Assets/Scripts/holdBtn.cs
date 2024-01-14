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
    private float duracionClicLargo = 1.0f; // Duraci�n en segundos para considerar un clic largo

    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Cuando se presiona el bot�n
        estaMantenido = true;
        tiempoInicioPulsacion = Time.time;

        // Realiza acciones adicionales al inicio del clic continuo aqu�
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
            // Se considera un clic largo
            Debug.Log("Bot�n clicado (clic largo)");
            PerkDescriptionPanel.SetActive(true);
        }
    }

    void Update()
    {
        // Si el bot�n est� siendo mantenido continuamente
        if (estaMantenido)
        {
            // Realiza acciones continuas aqu� (se ejecutar� cada frame mientras el bot�n est� mantenido)
            Debug.Log("Bot�n mantenido");
        }
    }
}
