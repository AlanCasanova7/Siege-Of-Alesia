using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopulationBar : MonoBehaviour
{

    public Image loadingBar;    //Filled img
    public Text feedbackText;
    public Text loadValText;    //Load percentage value
                                //public Image overlayPanel;  //Full screen img


    public string startText;

    public IntValue Current;

    void Start()
    {
        if (feedbackText)
            feedbackText.text = startText;
        loadingBar.fillAmount = 1;
    }

    void Update()
    {
        loadingBar.fillAmount = (Current.Value <= 0 ? 0 : Current.Value / (float)Current.Max);
        if (loadValText)
            loadValText.text = (Current.Value).ToString() + " / " + Current.Max;
    }
}
