using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ForwardScript : MonoBehaviour, IVirtualButtonEventHandler
{
    private GameObject button1;
    private TextMesh textmesh;
    public int seconds;
    // Start is called before the first frame update
    void Start()
    {
        button1 = GameObject.Find("VirtualButton1");
        textmesh = GameObject.Find("TextSeconds1").GetComponent<TextMesh>();
        button1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        seconds = 1;
    }
    
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.name == "VirtualButton1")
        {
            if (seconds < 5)
                seconds++;
            else
                seconds = 1;
            textmesh.text = seconds + " Seconds";
        }
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }
}
