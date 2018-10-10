using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    public int Index;
    [SerializeField]
    private KeysAttacks[] assignedInputs = new KeysAttacks[4];

    public int Population, Fervent;

    [SerializeField]
    private int maxChosenAttacks;
    public Queue<Attack> ChosenAttacks;
    public bool RecordInput;

    void Awake () 
    {
        //ChosenAttacks = new Queue<Attack>(4);
    }
	
	void Update ()
    {
        if (!RecordInput || ChosenAttacks.Count == maxChosenAttacks)
            return;

        if (Input.anyKeyDown)
        {
            for (int i = 0; i < assignedInputs.Length; i++)
            {
                if (Input.GetKeyDown(assignedInputs[i].Key))
                {
                    ChosenAttacks.Enqueue(assignedInputs[i].Attack);
                    Debug.Log(Index + " Recorded Input " + ChosenAttacks.Count);
                    if(ChosenAttacks.Count == maxChosenAttacks)
                    {
                        gameManager.SelectionFinished(this);
                    }
                }
            }
        }
	}

    public void SwitchToRecordState()
    {
        if(ChosenAttacks == null)
        {
            ChosenAttacks = new Queue<Attack>(4);
        }
        ChosenAttacks.Clear();
        RecordInput = true;
    }

    public void SwitchToFightState()
    {
        RecordInput = false;
    }


}
