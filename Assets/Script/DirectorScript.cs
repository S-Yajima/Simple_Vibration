using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript : MonoBehaviour
{
    // カメラのGameObjectへの参照。
    [SerializeField] private GameObject main_camera;
    // 単振動リングのObject。
    [SerializeField] private GameObject ring_sphere_0;
    [SerializeField] private GameObject ring_sphere_1;
    [SerializeField] private GameObject ring_sphere_2;
    [SerializeField] private GameObject ring_sphere_3;
    [SerializeField] private GameObject ring_sphere_4;
    [SerializeField] private GameObject ring_sphere_5;
    // 単振動リングの数
    private static int length = 6;
    // 単振動リングを格納する配列
    GameObject[] rings = new GameObject[DirectorScript.length];
    // 回転の中心座標
    private Vector3 rotate_center_pos = new Vector3(.0f, .0f, .0f);
    // Camera を動かし始めるフラグ
    private bool move_camera_flag = false;
    private float move_camera_angle = 0.0f;


    // 単振動を行うリングの初期配置を実行する
    // Y縦軸方向とリングの回転方向に回転を行う。
    // float angle : 生成する際にY軸とZ軸に傾ける角度
    void setting_ring(float angle, GameObject obj)
    {
        obj.transform.position = new Vector3(.0f, .0f, 0.886f);
        obj.transform.RotateAround(this.rotate_center_pos, Vector3.up, angle);
        Vector3 axis = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        obj.transform.RotateAround(rotate_center_pos, axis, angle);
    }

    // 単振動リングを表示する
    void show_ring_0()
    {
        this.ring_sphere_0.GetComponent<Vibration_Controller>().set_Visible_Flag(true);
    }

    void show_ring_1()
    {
        this.ring_sphere_1.GetComponent<Vibration_Controller>().set_Visible_Flag(true);
    }

    void show_ring_2()
    {
        this.ring_sphere_2.GetComponent<Vibration_Controller>().set_Visible_Flag(true);
    }

    void show_ring_3()
    {
        this.ring_sphere_3.GetComponent<Vibration_Controller>().set_Visible_Flag(true);
    }

    void show_ring_4()
    {
        this.ring_sphere_4.GetComponent<Vibration_Controller>().set_Visible_Flag(true);
    }

    void show_ring_5()
    {
        this.ring_sphere_5.GetComponent<Vibration_Controller>().set_Visible_Flag(true);
    }

    // カメラの投影方法を perspective(透視投影) にする
    void set_projection_perspective()
    {
        this.main_camera.GetComponent<Camera>().orthographic = false;
    }

    // カメラの投影方法を orthographic(平行投影) にする
    void set_projection_orthographic()
    {
        this.main_camera.GetComponent<Camera>().orthographic = true;
    }

    // カメラの位置と角度を変更する
    void move_camera()
    {
        this.move_camera_flag = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.rings[0] = this.ring_sphere_0;
        this.rings[1] = this.ring_sphere_1;
        this.rings[2] = this.ring_sphere_2;
        this.rings[3] = this.ring_sphere_3;
        this.rings[4] = this.ring_sphere_4;
        this.rings[5] = this.ring_sphere_5;

        // リングの回転の初期値を設定する
        float offset = 30.0f;
        float angle_z = 0.0f;
        for (int i = 0; i < this.rings.Length; i++)
        {
            setting_ring(angle_z, this.rings[i]);
            angle_z += offset;
        }

        // 時間の経過でリングを出現させる
        Invoke("show_ring_0", 3.0f);
        Invoke("show_ring_3", 15.0f);
        Invoke("show_ring_1", 25.0f);
        Invoke("show_ring_4", 25.0f);
        Invoke("show_ring_2", 35.0f);
        Invoke("show_ring_5", 35.0f);

        // カメラの投影方法を変更する
        Invoke("set_projection_perspective", 40.0f);
        Invoke("set_projection_orthographic", 50.0f);

        //Invoke("set_projection_perspective", 2.0f);//test
        Invoke("move_camera", 55.0f);
        Invoke("move_camera", 65.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.move_camera_flag == true)
        {
            // カメラの位置を公転回転させる
            this.main_camera.transform.RotateAround(this.rotate_center_pos, Vector3.right, 20.0f * Time.deltaTime);
            this.move_camera_angle += 20.0f * Time.deltaTime;
            // 90度回転した後、回転を止める
            if (this.move_camera_angle > 89.90f)
            {
                this.move_camera_angle = 0.0f;
                this.move_camera_flag = false;
            }
        }
    }
}
