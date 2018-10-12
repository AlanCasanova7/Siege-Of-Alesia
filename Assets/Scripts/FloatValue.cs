using UnityEngine;
[CreateAssetMenu]
public class FloatValue : ScriptableObject
{
    public float Value;
    [SerializeField]
    private bool resetOnCreation = false;
    [SerializeField]
    private float resetValue = 0.0f;
    [SerializeField]
    [TextArea(3, 5)]
    private string description;

    public void OnEnable()
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