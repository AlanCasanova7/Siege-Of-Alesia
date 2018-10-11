using UnityEngine;
[CreateAssetMenu]
public class IntValue : ScriptableObject
{
    public int Value { get { return value; } set { this.value = Mathf.Clamp(value, min, max); } }
    [SerializeField]
    private int min;
    [SerializeField]
    private int max;
    [SerializeField]
    private int value;


    [SerializeField]
    private bool resetOnCreation = false;
    [SerializeField]
    private int resetValue = 0;
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
}