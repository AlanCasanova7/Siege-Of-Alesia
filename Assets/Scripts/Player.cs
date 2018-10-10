using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Index;
    [SerializeField]
    private KeysAttacks[] assignedInputs = new KeysAttacks[4];
    [SerializeField]
    private Population population;
    [SerializeField]
    private Fervor fervor;
    [SerializeField]
    private int maxChosenAttacks;
    private Attack[] chosenAttacks;

    public Attack[] DEBUG_ATTACKS;

    void Awake () 
    {
        chosenAttacks = new Attack[maxChosenAttacks];
    }
	
	void Update ()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < assignedInputs.Length; i++)
            {
                if (Input.GetKeyDown(assignedInputs[i].Key))
                {
                    assignedInputs[i].Attack.FireAttack();
                }
            }
        }
	}
}
