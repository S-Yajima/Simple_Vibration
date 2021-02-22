using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 単振動の球体の部分
 */

public class Sphere_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 親GameObjectの表示フラグ「get_Visible_Flag」がtrueの場合は球体を表示する。
        Vibration_Controller parent = transform.parent.GetComponent<Vibration_Controller>();
        if (parent.get_Visible_Flag() == true)
        {
            Color color = GetComponent<Renderer>().material.color;
            color.a = 1.0f;
            GetComponent<Renderer>().material.color = color;
        }
    }
}
