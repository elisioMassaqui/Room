using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Ports;
public class toggle : MonoBehaviour
{
    public SerialPort serialPort = new SerialPort("COM9", 9600);
    public Toggle toggle01;
    public TMP_Text counting;
    public float numberCount;

    public float velocityCount;
    public Slider slidervelocityCount;

    // Start is called before the first frame update.
    void Start()
    {
        slidervelocityCount.value = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        slidervelocityCount.minValue = 0f;
        slidervelocityCount.maxValue = 30f;
        velocityCount = slidervelocityCount.value;

        counting.text = $"Contando >> {numberCount}";
      
    }

    public void contarButton(){

         if (toggle01.isOn == true)
        {
            StartCoroutine(trocarEstado());
            numberCount += 1f * velocityCount * Time.deltaTime;
        }
    }

    IEnumerator trocarEstado(){

            yield return new WaitForSeconds(10f);
            numberCount = 0;
            toggle01.isOn = false;
            toggle01.interactable = false;
            serialPort.WriteLine("A");
            yield return new WaitForSeconds(1f);
            numberCount = 0;
            toggle01.isOn = false;
            toggle01.interactable = true;
    }
}
