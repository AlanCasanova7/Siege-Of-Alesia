using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnergyBarLogic : MonoBehaviour
{
    public Image loadingBar;    //Filled img
    public Text feedbackText;
    public Text loadValText;    //Load percentage value
                                //public Image overlayPanel;  //Full screen img

    //Increment values (Loading bar, overlay white panel alpha fade in)
    public float loadingIncVal;
    public float alphaIncVal;

    //feedbackText == startText at the beginning, endText after loading == 100
    public string startText;

    public FloatValue Max;
    public FloatValue Current;
   
    void Start()
    {
        feedbackText.text = startText;
        loadingBar.fillAmount = 1;
    }

    void Update()
    {
        loadingBar.fillAmount = (Current.Value <= 0 ? 0 : Current.Value / Max.Value);
        loadValText.text = ((int)(loadingBar.fillAmount * 100)).ToString("") + " / 100";
    }
}