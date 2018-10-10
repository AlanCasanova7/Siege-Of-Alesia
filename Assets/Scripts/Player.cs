using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BooleanValue ReadyStatus;

    public int Index;
    [SerializeField]
    private KeysAttacks[] assignedInputs = new KeysAttacks[4]; 

    public int Population, Fervent;

    [SerializeField]
    private int maxChosenAttacks;
    public Queue<Attack> ChosenAttacks;
    public bool RecordInput;

    public void FillEmptyAttackSlots()
    {
        while (ChosenAttacks.Count != maxChosenAttacks)
        {
            ChosenAttacks.Enqueue(assignedInputs[UnityEngine.Random.Range(0, assignedInputs.Length)].Attack);
        }
    }
    void Update()
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
                    if (ChosenAttacks.Count == maxChosenAttacks)
                    {
                        ReadyStatus.Value = true;
                    }
                }
            }
        }
    }

    public void SwitchToRecordState()
    {
        if (ChosenAttacks == null)
        {
            ChosenAttacks = new Queue<Attack>(maxChosenAttacks);
        }

        ChosenAttacks.Clear();
        RecordInput = true;
    }

    public void SwitchToFightState()
    {
        RecordInput = false;
    }


}
