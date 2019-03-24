using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerScript : MonoBehaviour, IVirtualButtonEventHandler
{
    private GameObject button0;

    private GameObject it1;
    private ForwardScript forward;

    private GameObject player;
    private Animator anim;

    private bool boolforward;
    // Start is called before the first frame update
    void Start()
    {
        button0 = GameObject.Find("VirtualButton0");
        button0.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        it1 = GameObject.Find("ImageTarget1");
        forward = it1.GetComponent<ForwardScript>();

        player = GameObject.Find("Walk");
        anim = player.GetComponent<Animator>();
        anim.Play("idle");

        boolforward = false;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.name == "VirtualButton0")
        {
            boolforward = true;
            player.transform.localPosition = Vector3.zero;
            Invoke("stopMoving", forward.seconds);
            anim.Play("walk");
        }
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }

    void Update()
    {
        if (boolforward)
            player.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
    }
    public void stopMoving()
    {
        boolforward = false;
        anim.Play("idle");
    }
}
