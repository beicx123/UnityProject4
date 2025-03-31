using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MessageType
{
    GOID,
}

public class MessageManager : SingleManager<MessageManager>
{
    public Dictionary<MessageType, Action<ModelBase>> modeldic = new Dictionary<MessageType, Action<ModelBase>>();

    //注册消息
    public void ZhuCeMessage(MessageType type,Action<ModelBase> funtion)
    {
        if (modeldic.ContainsKey(type))
        {
            modeldic[type] += funtion;
        }
        else
        {
            modeldic.Add(type, funtion);
        }
    }

    public void ShanChuMessage(MessageType type, Action<ModelBase> funtion)
    {
        if (modeldic.ContainsKey(type))
        {
            modeldic[type] -= funtion;
            if(modeldic[type] == null)
            {
                modeldic.Remove(type);
            }
        }
    }

    public void FaSongMessage(MessageType type, ModelBase model)
    {
        if (modeldic.ContainsKey(type))
        {
            modeldic[type](model);
        }
    }
}
