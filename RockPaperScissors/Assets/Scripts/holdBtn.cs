using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class holdBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool estaMantenido = false;
    private float tiempoInicioPulsacion;
    private float duracionClicLargo = 0.5f;
    private GameObject panel;

    void Start()
    {
        //Finding the panel
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
        estaMantenido = true;
        tiempoInicioPulsacion = Time.time;

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
            Debug.Log("Botón clicado (clic largo)");
            panel.SetActive(true);
        }
    }

    void Update()
    {

    }
}
