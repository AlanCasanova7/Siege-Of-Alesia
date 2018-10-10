using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public KeysAttacks[] assignedInputs = new KeysAttacks[4];

	void Start () 
    {
		
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
