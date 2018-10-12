using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowTutorial : MonoBehaviour
{

    public Sprite Tutorial;
    public Image Img;
    public Color WithImage;
    private Color other;
    private void Start()
    {
        other = Img.color;
    }
    public void SetTutorial()
    {
        Img.color = WithImage;
        Img.sprite = Tutorial;
    }
    public void RemoveTutorial()
    {
        Img.sprite = null;
        Img.color = other;
    }
}
