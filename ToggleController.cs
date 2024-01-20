using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Ports;

public class ToggleController : MonoBehaviour
{
    public SerialPort serialPort = new SerialPort("COM17", 9600);
    public Toggle toggle01;
    public TMP_Text counting;
    public float numberCount;

    public float velocityCount;
    public Slider slidervelocityCount;

    private bool isToggleActive = false;
    private float toggleTimer = 0f;
    private const float toggleDuration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        slidervelocityCount.value = 15f;
        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
        slidervelocityCount.minValue = 0f;
        slidervelocityCount.maxValue = 30f;
        velocityCount = slidervelocityCount.value;

        counting.text = $"Contando >> {numberCount}";

        if (isToggleActive)
        {
            toggleTimer += Time.deltaTime;

            if (toggleTimer >= toggleDuration)
            {
                toggle01.isOn = false;
                toggle01.interactable = true;
                isToggleActive = false;
                numberCount = 0;
                toggleTimer = 0f;
            }
        }

        ativarLed();
    }

    public void ativarLed()
    {
        StartCoroutine(trocarEstado());
        numberCount += 1f * velocityCount * Time.deltaTime;

        if (toggle01.isOn && !isToggleActive)
        {
            isToggleActive = true;
            toggle01.interactable = false;

            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.WriteLine("B");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }

    IEnumerator trocarEstado()
    {
        yield return null; // Mantém o método Coroutine, mas não faz nada.
    }
}
