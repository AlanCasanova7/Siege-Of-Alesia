using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextsIntroLogic2 : MonoBehaviour
{
    public Text text;
    [SerializeField]
    float time = 0;
    public float[] timers = new float[10];
    public string[] TextsIntro = new string[10];

    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;

        if (time < timers[0])
        {

            text.text = TextsIntro[0];

        }
        else if (time > timers[0] && time < timers[1])
        {
            text.text = TextsIntro[1];

        }
        else if (time > timers[1] && time < timers[2])
        {
            text.text = TextsIntro[2];

        }
        else if (time > timers[2] && time < timers[3])
        {
            text.text = TextsIntro[3];

        }
        else if (time > timers[3] && time < timers[4])
        {
            text.text = TextsIntro[4];

        }
        else if (time > timers[4] && time < timers[5])
        {
            text.text = TextsIntro[5];

        }
        else if (time > timers[5] && time < timers[6])
        {
            text.text = TextsIntro[6];

        }
        else if (time > timers[6] && time < timers[7])
        {
            text.text = TextsIntro[7];

        }
        else if (time > timers[7] && time < timers[8])
        {
            text.text = TextsIntro[8];

        }
        else if (time > timers[8] && time < timers[9])
        {
            text.text = TextsIntro[9];
        }
    }
}
