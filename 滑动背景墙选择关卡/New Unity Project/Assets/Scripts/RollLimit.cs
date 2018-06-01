using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 挂在两边的墙上:LeftWall和RightWall分别挂一个
/// </summary>
public class RollLimit : MonoBehaviour 
{
    public GameObject walls; //获取背景墙

    //这个函数表示该脚本物体进入当前任意摄像机视锥内调用一次
    void OnBecameVisible() 
    {
        switch (name) //根据当前脚本物体的名字修改背景墙的状态
        {
            case "LeftWall": //如果左边界墙进入摄像机视锥范围,背景墙状态变为超越左边界
                walls.GetComponent<BackGroundRolling>().state = RollState.BeyondLeft;
                break;
            case "RightWall": //原理同上
                walls.GetComponent<BackGroundRolling>().state = RollState.BeyondRight;
                break;
        }
    }
    //这个函数表示该脚本物体离开所有当前摄像机视锥范围调用一次
    void OnBecameInvisible()
    {
        //背景墙状态变为普通
        walls.GetComponent<BackGroundRolling>().state = RollState.Normal;
    }
}
