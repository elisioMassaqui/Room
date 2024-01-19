using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toggle : MonoBehaviour
{
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
            numberCount += 1f * velocityCount;
        }
    }

    IEnumerator trocarEstado(){

            yield return new WaitForSeconds(5f);
            numberCount = 0;
            toggle01.isOn = false;
            toggle01.interactable = false;
            yield return new WaitForSeconds(1f);
            toggle01.interactable = true;

       
    }
}
