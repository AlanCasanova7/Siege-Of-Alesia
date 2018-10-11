using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FervorSlider : MonoBehaviour
{

    public Slider Slider;

    public IntValue Current;

    void Start()
    {
        this.Slider.value = 0;
        this.Slider.minValue = Current.Min;
        this.Slider.maxValue = Current.Max;
    }

    void Update()
    {
        this.Slider.value = Current.Value;
    }
}
