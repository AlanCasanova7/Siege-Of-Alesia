using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLogic : MonoBehaviour
{
    public Image BG_Image;
    public Image Cover_Image;
    public Image Number_Image;

    public Color ChoosedCardColor;
    public Color DefaultCardColor;
    
    public void ShowChoosedCard(Sprite sprite)
    {
        BG_Image.sprite = sprite;
        Cover_Image.enabled = false;
        Number_Image.enabled = false;
    }

    public void ResetCard()
    {
        BG_Image.color = DefaultCardColor;
        BG_Image.sprite = null;
        BG_Image.enabled = true;
        Cover_Image.enabled = true;
        Number_Image.enabled = true;
    }
    public void CardChoosed()
    {
        BG_Image.color = ChoosedCardColor;
    }
}
