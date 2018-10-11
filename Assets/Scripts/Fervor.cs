using UnityEngine;
[CreateAssetMenu]
public class Fervor : ScriptableObject
{
    public int[] DmgValues = new int[7];
    public int[] RecoverValues = new int[7];
    public int[] SelfDmgValues = new int[7];
    void OnValidate()
    {
        if (DmgValues.Length != 7)
            DmgValues = new int[7];
        if (RecoverValues.Length != 7)
            RecoverValues = new int[7];
        if (SelfDmgValues.Length != 7)
            SelfDmgValues = new int[7];
    }
}
