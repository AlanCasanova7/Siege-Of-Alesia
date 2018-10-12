using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCinematic : MonoBehaviour
{
    [SerializeField]
    float time;

    public float Timer1;
    public float Timer2;
    public float Timer3;
    public float Timer4;
    public float Timer5;
    public float Timer6;
    public float Timer7;
    public float Timer8;
    public float Timer9;

    float Speed1 = 0.2f;
    float Speed2 = 0.4f;
    float Speed3 = 0.6f;
    float Speed4 = 0.8f;
    float Speed5 = 1f;
    float Speed6 = 1.3f;
    float Speed7 = 1.6f;
    float Speed8 = 1.9f;
    float Speed9 = 2.4f;
    float Speed10 = 3f;

    public Transform CameraPosition1;
    public Transform CameraPosition2;
    public Transform CameraPosition3;

    public Transform FinalCamera;
    // Use this for initialization
    void Start()
    {
        time = 0;
        //time = Timer8;
        //time = Timer9;

        transform.position = CameraPosition1.position;
        //transform.position = CameraPosition2.position;
        //transform.position = CameraPosition3.position;

        transform.forward = CameraPosition1.forward;
        //transform.forward = CameraPosition2.forward;
        //transform.forward = CameraPosition3.forward;
    }


    bool skip = false;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time <= Timer7)
        {
            RomeTour();
        }
        else if (time > Timer7 && time < Timer9)
        {
            CartagineTour();
        }
        else if (time > Timer9)
        {
            CombatFieldTour(FinalCamera);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skip == false)
            {
                time = Timer9;
                transform.position = FinalCamera.position;
                transform.rotation = FinalCamera.rotation;
                skip = true;
            }
        }
    }

    private void RomeTour()
    {
        if (time >= Timer1 && time <= Timer2)
        {
            transform.Translate(Speed1 * Time.deltaTime, 0, 0);
        }
        else if (time >= Timer2 && time <= Timer3)
        {
            transform.Translate(Speed2 * Time.deltaTime, Speed1 * Time.deltaTime, 0);

            transform.Rotate(-Speed1 * Time.deltaTime, -Speed2 * Time.deltaTime, 0);
        }
        else if (time >= Timer3 && time <= Timer4)
        {
            transform.Translate(Speed3 * Time.deltaTime, Speed2 * Time.deltaTime, Speed2 * Time.deltaTime);

            transform.Rotate(-Speed2 * Time.deltaTime, -Speed3 * Time.deltaTime, 0);
        }
        else if (time >= Timer4 && time <= Timer5)
        {
            transform.Translate(Speed2 * Time.deltaTime, Speed2 * Time.deltaTime, Speed2 * Time.deltaTime);

            transform.Rotate(-Speed3 * Time.deltaTime, -Speed4 * Time.deltaTime, 0);
        }
        else if (time >= Timer5 && time <= Timer6)
        {
            transform.Translate(Speed1 * Time.deltaTime, Speed3 * Time.deltaTime, -Speed5 * Time.deltaTime);
        }
        else if (time >= Timer6 && time <= Timer7)
        {
            transform.Translate(0, 0, -Speed10 * Time.deltaTime);
        }
    }
    private void CartagineTour()// LERP
    {
        if (time >= Timer7 && time <= Timer8)
        {
            transform.position = Vector3.Lerp(transform.position, CameraPosition2.position, 0.01f);
            transform.rotation = Quaternion.Lerp(transform.rotation, CameraPosition2.rotation, 0.02f);
            // transform.Rotate(0, -Speed4 * Time.deltaTime, 0);
        }
        else if (time >= Timer8 && time <= Timer9)
        {
            transform.position = Vector3.Lerp(transform.position, CameraPosition3.position, 0.002f);
            transform.rotation = Quaternion.Lerp(transform.rotation, CameraPosition3.rotation, 0.01f);

            //transform.Rotate(-Speed3 * Time.deltaTime, -Speed4 * Time.deltaTime, 0);
        }
    }

    private void CombatFieldTour(Transform CombatCameraPosRot)
    {
        transform.position = Vector3.Lerp(transform.position, FinalCamera.position, 0.01f);
        transform.rotation = Quaternion.Lerp(transform.rotation, FinalCamera.rotation, 0.01f);
        this.GetComponent<Camera>().fieldOfView=7.1f;
        
    }
}
