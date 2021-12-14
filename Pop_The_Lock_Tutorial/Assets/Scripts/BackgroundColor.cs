using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{

    public List<Color> colorList;
    //public float duration = 3.0F;

    private Camera cam;
    /*
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainCamera");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
*/
    void Start()
    {
        cam = GetComponent<Camera>();
        //cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        //float t = Mathf.PingPong(Time.time, duration) / duration;
        //cam.backgroundColor = Color.Lerp(color1, color2, t);
    }

    public void ChangeBackgroundColor()
    {
        cam.backgroundColor = colorList[Random.Range(0,colorList.Count)];
    }
}
