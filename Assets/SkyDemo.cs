using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyDemo : MonoBehaviour {

	public float rotateSpeed = 15.0f; //set rotate speed of camera(设置摄像机的旋转速度
	    private GameObject camera1;    //declare gameobject(声明游戏对象用来获取摄像机
	    public Material[] First;                //declare material array used to place the sky boxes that need to be switched (声明材质数组用于放置需要切换的天空盒
	    public Material[] Second;
	    private int index;                      //first array index(第一个材质数组的索引
	    private int deindex;                    //second array index(第一个材质数组的索引
	    void Awake() {
		        camera1 = transform.Find("Camera (1)").gameObject;
		        //get the Camera(1) and transform to gameObject(获取挂载该脚本的游戏对象下名为“Camera （1）”的子对象并将其转换为GameObject类型
		    }
	    void Update () {
		        this.transform.Rotate(new Vector3(0,rotateSpeed*Time.deltaTime,0)); 
		        //rotate around y axis
		        if (Input.GetKeyDown(KeyCode.Space)){   //monitor keyboard and judge if space is pressed(添加键盘监听，判断空格键是否被按下
			            RenderSettings.skybox = First[index++%First.Length];   // modify the skybox material in light panel(修改Light面板中的Skybox材质
			            camera1.transform.GetComponent<Skybox>().material = Second[deindex++ % Second.Length];   //modify the skybox in camera (修改摄像机上天空盒组件的Skybox材质
			        }
		    }
}
