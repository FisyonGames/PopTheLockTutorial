using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{

    public List<Color> colorList;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.backgroundColor = colorList[0];
    }

    public void ChangeBackgroundColor()
    {
        cam.backgroundColor = colorList[1];
    }
}
