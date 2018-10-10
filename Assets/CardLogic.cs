using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLogic : MonoBehaviour
{
    public Image BG_Image;
    public Image Cover_Image;
    public Image Number_Image;

    public Sprite Sprite;

    public void ShowChoosedCard(Sprite sprite)
    {
        BG_Image.sprite = sprite;
        Cover_Image.enabled = false;
        Number_Image.enabled = false;
    }

    public void ResetCard()
    {
        BG_Image.sprite = null;
        Cover_Image.enabled = true;
        Number_Image.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ShowChoosedCard(Sprite);
        }
        else
        {
            ResetCard();
        }
    }
}
