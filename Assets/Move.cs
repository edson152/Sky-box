using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	CharacterController controller;     //declare character controller
	    public float pushPower = 5.0F;      //power to push 
	    public float speed = 6.0f;          //speed to move
	    public float rotateSpeed=3.0f;      //speed to rotate
	    void Awake() {
		        controller = this.GetComponent<CharacterController>();  //get its character controller
		    }
	    void Update() {        
		        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotateSpeed, 0)); //rotate player when pressing directional key “←”“→”
		        Vector3 forward = transform.TransformDirection(Vector3.forward);    //transform from self coordinate system to world coordinate system
		        controller.SimpleMove(forward * speed*Input.GetAxis("Vertical"));   //move the player when pressing the directional key“↑”“↓”
		    }
	    void OnControllerColliderHit(ControllerColliderHit hit)     //called when hit the movable gameobject 当碰撞到可移动的物体时被调用
	    {
		        Rigidbody body = hit.collider.attachedRigidbody;      //get the rigidbody of hit GameObject (获取被碰撞的物体的刚体组件)
		        if (body == null || body.isKinematic)    //if there is no rigidbody or it does not meet the laws of kinematics (如果物体没有刚体组件或不符合运动学定律就返回)
			            return;
		        if (hit.moveDirection.y < -0.3F)   //return if the y-axis component in the direction from center of capsule to touched point is less than -0.3(如果胶囊碰撞器中心到触碰点的方向在y轴的分量小于-0.3时返回)
			            return;
		        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z); //set the moving direction of hit gameobject(设置被碰撞的物体的移动方向)
		        body.velocity = pushDir * pushPower;        //add velocity on hit gameObject(为被碰撞的物体施加速度)
		    }
}
