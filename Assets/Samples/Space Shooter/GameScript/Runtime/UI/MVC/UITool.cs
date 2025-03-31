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
    //���ٻ�ȡһ��gameobject�µ��ӽڵ�
    public Transform GetChild(Transform parent,string name)
    {

        Transform child = null;
        child = parent.transform.Find(name);
        if(child == null)
        {
            foreach(Transform i in parent.transform)
            {
                //���õݹ�
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
