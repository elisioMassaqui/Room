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
    private const float toggleDuration = 5f;

    // Start is called before the first frame update.
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

                ativarLed();

        if (isToggleActive)
        {
            toggleTimer += Time.deltaTime;
            numberCount += 1f * velocityCount * Time.deltaTime;

            StartCoroutine(trocarEstado());

            if (toggleTimer >= toggleDuration)
            {
                toggle01.isOn = false;
                toggle01.interactable = true;
                isToggleActive = false;
                numberCount = 0;
                toggleTimer = 0f;
            }
        }

    }

    public void ativarLed()
    {

        if (toggle01.isOn && !isToggleActive)
        {
            isToggleActive = true;
            toggle01.interactable = false;
        }
    }

    IEnumerator trocarEstado()
    {
          if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write("B");
                    Debug.Log("Enviando Signal");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        yield return new WaitForSeconds(0.1f);
    }
}
