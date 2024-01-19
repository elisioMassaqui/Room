using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class imageColor : MonoBehaviour
{
    public Image imageCor;
    public TMP_Dropdown DropdownColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            imageCor.color = Color.red;
        }
        switch (DropdownColor.value)
        {
           case 0:
           imageCor.color = Color.white;
           break;
           case 1:
           imageCor.color = Color.red;
           break;
           case 2:
           imageCor.color = Color.blue;
           break;
           case 3:
           imageCor.color = Color.white;
           break;
           case 4:
           imageCor.color = Color.black;
           break;
           case 5:
           imageCor.color = Color.green;
           break;
           case 6:
           imageCor.color = Color.red;
           break;
           case 7:
           imageCor.color = Color.green;
           break;
           case 8:
           imageCor.color = Color.blue;
           break;
           case 9:
           imageCor.color = Color.white;
           break;
        }
    }
}
