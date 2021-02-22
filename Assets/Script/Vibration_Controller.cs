using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration_Controller : MonoBehaviour
{
    // 角速度(角振動数)。degree値。
    private float w = 45.0f;

    [SerializeField] private bool visible_flag = false;

    // 表示フラグを返す。
    public bool get_Visible_Flag()
    {
        return this.visible_flag;
    }

    // 表示フラグを設定する。
    public void set_Visible_Flag(bool flag)
    {
        this.visible_flag = flag;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    * 一定時間毎に自動で実行される。
    * 物理演算は当メソッドで実行する。
    */
    void FixedUpdate()
    {
        transform.Rotate(0.0f, this.w * Time.deltaTime, 0.0f, Space.Self);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
