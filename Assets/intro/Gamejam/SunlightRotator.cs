using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunlightRotator : MonoBehaviour
{
    public Vector3 StartEuler;

    public float X;
    public float Y;
    public float Z;

    public float DaySpeed;
    [SerializeField]
    float time =0;
    // Use this for initialization
    void Start()
    {
        transform.eulerAngles = StartEuler;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 40)
        {
            transform.Rotate(X * Time.deltaTime * DaySpeed, Y * Time.deltaTime * DaySpeed, Z * Time.deltaTime * DaySpeed);
        }
        else
            transform.Rotate(0, 0, 0);
    }
}
