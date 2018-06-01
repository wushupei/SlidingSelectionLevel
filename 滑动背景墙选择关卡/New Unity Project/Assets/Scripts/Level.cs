using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 每个关卡(三角形几何体)上都挂一个
/// </summary>
public class Level : MonoBehaviour
{
    public bool up; //用来判断当前关卡浮动状态
    Vector2 initialPosition; //声明初始位置
    float UpperLimit; //浮动上限
    float lowerLimit; //浮动下限 
    public float speed; //浮动速度
    public float range; //浮动幅度
    private void Start()
    {
        initialPosition = transform.position; //获取一开始的位置作为初始位置
    }
    private void Update()
    {
        UpperLimit = initialPosition.y + range; //定义浮动上限
        lowerLimit = initialPosition.y - range; //定义浮动下限
        //如果关卡为上浮状态
        if (up)
        {
            //关卡往上浮
            transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
            //如果浮动上限
            if (transform.position.y >= UpperLimit)
                up = false; //关卡变为下浮状态
        }
        //原理同上
        else
        {
            transform.Translate(-Vector2.up * speed * Time.deltaTime, Space.World);
            if (transform.position.y <= lowerLimit)
                up = true;
        }
    }
    //关卡的eventTrigger组件里设置点击事件,将该方法添加进去,点击关卡即可执行该方法
    public void GetPlayer()
    {
        //在场景中找到主角
        Transform player = GameObject.Find("Player").transform;
        //改变主角坐标
        player.position = new Vector2(transform.position.x, transform.position.y + 1);
        player.parent = transform; //将主角作为自己的子物体,随自己沉浮
    }
}
