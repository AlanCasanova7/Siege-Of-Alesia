using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsHolder : MonoBehaviour
{
    public CardLogic[] Cards;

    public GameManager Manager;

    private int index;

    public void ExposeCard(Sprite sprite)
    {

        if (index >= Cards.Length)
        {
            index = 0;
        }
        Cards[index].ShowChoosedCard(sprite);
        index++;
    }

    public void ResetAllCards()
    {


        for (int i = 0; i < Cards.Length; i++)
        {
            Cards[i].ResetCard();
        }
        index = 0;
    }

    public void ChoosedCardColorMethod()
    {

        if (index >= Cards.Length)
        {
            index = 0;
        }
        Cards[index].CardChoosed();
        index++;
    }
}
