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
        Max.Value = 100;
        feedbackText.text = startText;
        loadingBar.fillAmount = 1;
    }

    void Update()
    {
        //If the loading bar is full
        //{
        //    loadingBar.fillAmount = 1;
        //    feedbackText.text = endText;
        //    loadValText.enabled = false;
        //    //if (overlayPanel.color.a < 1)
        //    //{
        //    //    overlayAlpha += alphaIncVal;
        //    //    overlayPanel.color = new Color(1, 1, 1, overlayAlpha);
        //    //}
        //    //else
        //        if (Application.isEditor)
        //        //If we are in Editor
        //        UnityEditor.EditorApplication.isPlaying = false;
        //    else
        //        //If we are in a build
     
        //else
        //{
        //If the loading bar is not full, increase the filling value id space is pressed, decrease otherwise


        if (Current.Value < 0)
        {
            Current.Value = 0;          
        }
        else if (Current.Value >= Max.Value)
        {
            Current.Value = Max.Value;
            feedbackText.text = startText;
        }

        loadingBar.fillAmount = (Current.Value == 0 ? 0 : Current.Value / Max.Value);
        loadValText.text = ((int)(loadingBar.fillAmount * 100)).ToString("") + " / 100";
    }
}