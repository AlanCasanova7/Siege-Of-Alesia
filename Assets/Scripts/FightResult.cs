using UnityEngine;
[CreateAssetMenu]
public class FightResult : ScriptableObject
{
    public int SelfDamage = 0;
    public int ReceivedDamage = 0;
    public void Reset()
    {
        SelfDamage = 0;
        ReceivedDamage = 0;
    }
    public void OnEnable()
    {
        Reset();
    }
}