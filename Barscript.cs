﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barscript : MonoBehaviour
{

   //healthbar script 
    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;


    [SerializeField]
    private Image content;

    [SerializeField]
    private Text valueText;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();

    }

    private void HandleBar()
    {

        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount,Time.deltaTime * lerpSpeed);
        }
    }

    // mapear o health e transformar no valor de 0-1 para o fillAmount - value=health, inMin=valor minimo, inMax=valor maximo, outMax - 1, outMin - 0
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

}
