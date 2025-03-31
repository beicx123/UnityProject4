using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UiType
{
    固定,
    常用,
    提示
}
public class UIBase
{
    public string path; //需要加载的面板路径

    GameObject go; //面板物体

    public UiType m_type; //UI层级
    public UIBase(string path, UiType type)
    {
        this.path = path;
        m_type = type;
    }

    public virtual void Init(GameObject gameobj)
    {
        this.go = gameobj;
    }


    //update实现更新
    public virtual void Update()
    {

    }

    public virtual void Destroy()
    {
        GameObject.Destroy(go);
    }

}
