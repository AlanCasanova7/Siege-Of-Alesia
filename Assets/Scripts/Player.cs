using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent InputSelected;
    public BooleanValue ReadyStatus;

    public int Index;
    [SerializeField]
    private KeysAttacks[] assignedInputs = new KeysAttacks[4]; 

    public IntValue Population;
    public IntValue Fervor;

    [SerializeField]
    private int maxChosenAttacks;
    public Queue<Attack> ChosenAttacks;
    public Queue<AttackAnimation> ChosenAttacksAnim;
    public bool RecordInput;

    public void FillEmptyAttackSlots()
    {
        while (ChosenAttacks.Count != maxChosenAttacks)
        {
            KeysAttacks att = assignedInputs[UnityEngine.Random.Range(0, assignedInputs.Length)];
            ChosenAttacks.Enqueue(att.Attack);
            ChosenAttacksAnim.Enqueue(att.AnimationManager);
            InputSelected.Invoke();
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
                    ChosenAttacksAnim.Enqueue(assignedInputs[i].AnimationManager);
                    InputSelected.Invoke();
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
            ChosenAttacksAnim = new Queue<AttackAnimation>(maxChosenAttacks);
        }

        ChosenAttacks.Clear();
        RecordInput = true;
    }

    public void SwitchToFightState()
    {
        RecordInput = false;
    }


}
