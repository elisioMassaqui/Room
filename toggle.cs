using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Ports;
public class toggle : MonoBehaviour
{
    public SerialPort serialPort = new SerialPort("COM17", 9600);
    public Toggle toggle01;
    public TMP_Text counting;
    public float numberCount;

    public float velocityCount;
    public Slider slidervelocityCount;

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
    }

    public void ativarLed(){

            StartCoroutine(trocarEstado());
            numberCount += 1f * velocityCount * Time.deltaTime;
        if (toggle01.isOn == true)
        {
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

    IEnumerator trocarEstado(){

        while (true)
        {
            yield return new WaitForSeconds(100f);
            toggle01.isOn = false;
            toggle01.interactable = true;
            numberCount = 0; 
        }

            
    }
}
