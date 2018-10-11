using UnityEngine;
[CreateAssetMenu]
public class BooleanValue : ScriptableObject
{
    public bool Value;


    [SerializeField]
    private bool resetOnCreation = false;
    [SerializeField]
    private bool resetValue = false;
    [SerializeField]
    [TextArea(3, 5)]
    private string description;

    private void OnEnable()
    {
        if (resetOnCreation)
            Value = resetValue;
    }
    private void OnValidate()
    {
        if (resetOnCreation)
            Value = resetValue;
    }
    public void Set(bool value)
    {
        Value = value;
    }
}