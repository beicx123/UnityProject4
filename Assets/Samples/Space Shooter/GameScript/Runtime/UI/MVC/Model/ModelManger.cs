using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManger : SingleManager<ModelManger>
{
    Dictionary<Type, ModelBase> basedic = new Dictionary<Type, ModelBase>();

    //获取model
    public T GetModel<T>() where T : ModelBase 
    {
        Type type = typeof(T);

        if (basedic.ContainsKey(type))
        {
            return basedic[type] as T;
        }
        else
        {
            ModelBase mbase = Activator.CreateInstance(type) as ModelBase;
            //初始化逻辑调用
            mbase.Init();

            basedic.Add(type, mbase);

            return basedic[type] as T;
        }
    }
} 
