using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RollState //背景墙状态机
{
    Normal, //正常状态
    BeyondLeft, //超越左边
    BeyondRight, //超越右边
}
public class BackGroundRolling : MonoBehaviour //背景墙滚动
{
    public float RollSpeed; //背景墙移动速度
    public RollState state = RollState.Normal; //初始状态为普通状态
    private void Update()
    {
        switch (state) //判断墙壁当前状态
        {
            case RollState.BeyondLeft: //超出左边边界墙壁往左跑
                transform.Translate(Vector2.left * Time.deltaTime);
                break;
            case RollState.BeyondRight: //超出右边边界墙壁往右跑
                transform.Translate(Vector2.right * Time.deltaTime);
                break;
        }
    }
    //背景墙的EventTrigger组件设置了拖动事件,将下面的滚动方法放进该事件中
    public void Roll() 
    {
        if (state == RollState.Normal) //如果墙壁为普通状态
        {
            //获取鼠标位置信息,鼠标往-x方向移动dirx<0,反之dirx>0,不移动dirx=0
            float dirX = Input.GetAxis("Mouse X"); 
            //背景墙在x轴上移动
            transform.Translate(Vector2.right * dirX * RollSpeed * Time.deltaTime,Space.World);
        }
    }
}
