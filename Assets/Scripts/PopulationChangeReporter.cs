using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopulationChangeReporter : MonoBehaviour
{

    public Text Text;
    public CanvasGroup Group;
    public AnimationCurve AlphaCurve;
    public Color SelfInflictedDamage;
    public Color ReceivedDamage;
    public Color PopulationRecovered;
    public float PopupDuration = 2f;

    private float timer;
    private void Start()
    {
        this.enabled = false;
        Group.alpha = 0f;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        float alpha = AlphaCurve.Evaluate(timer / PopupDuration);
        Group.alpha = alpha;
        if(timer > PopupDuration)
        {
            timer = 0f;
            this.enabled = false;
        }
    }

    public void PopRecovered(int amount)
    {
        this.enabled = true;
        Text.color = PopulationRecovered;
        Text.text = "+" + amount;
    }
    public void DmgReceived(int amount)
    {
        this.enabled = true;
        Text.color = ReceivedDamage;
        Text.text = "-" + amount;
    }
    public void SelfDmg(int amount)
    {
        this.enabled = true;
        Text.color = SelfInflictedDamage;
        Text.text = "-" + amount;
    }
}
