using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITool 
{
    private static UITool instance;
    public static UITool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UITool();
            }
            return instance;
        }
    }
    //快速获取一个gameobject下的子节点
    public Transform GetChild(Transform parent,string name)
    {

        Transform child = null;
        child = parent.transform.Find(name);
        if(child == null)
        {
            foreach(Transform i in parent.transform)
            {
                //运用递归
                child = GetChild(i,name);
                if(child != null)
                {
                    break;
                }
            }
        }
        return child;
    }


}
