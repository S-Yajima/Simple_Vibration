using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vibration_Controller parent = transform.parent.GetComponent<Vibration_Controller>();

        if (parent.get_Visible_Flag() == true)
        {
            Color color = GetComponent<Renderer>().material.color;
            //Debug.Log(color.a);
            if (color.a < 0.49f)
            {
                color.a += 0.002f;
                GetComponent<Renderer>().material.color = color;
            }
        }
    }
}
