using UnityEngine;
using UnityEngine.Events;
public class AttacksAnimationsWatcher : MonoBehaviour
{
    public UnityEvent AnimationsOver;

    public BooleanValue Animation1Status;
    public BooleanValue Animation2Status;

    private void Update()
    {
        if (Animation1Status.Value && Animation2Status.Value)
        {
            AnimationsOver.Invoke();
        }
    }
}