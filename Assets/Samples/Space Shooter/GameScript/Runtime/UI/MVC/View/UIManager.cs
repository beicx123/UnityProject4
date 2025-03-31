using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  负责管理所有UI界面，
///  保证界面层级与存储的层级一致
///  面板路径保持一致
/// </summary>
public class UIManager : SingleManager<UIManager>
{

    public Dictionary<Type, UIBase> m_AllPanel = new Dictionary<Type, UIBase>(); //类型 + 继承uibase的脚本（面板）

    public Dictionary<UiType, GameObject> m_AllPanelObj = new Dictionary<UiType, GameObject>();

    public UIManager()
    {
        m_AllPanelObj.Add(UiType.固定, GameObject.Find("Canvas/固定"));
        m_AllPanelObj.Add(UiType.常用, GameObject.Find("Canvas/常用"));
        m_AllPanelObj.Add(UiType.提示, GameObject.Find("Canvas/提示"));
    }
    //打开面板
    public void Open<T>()where T:UIBase
    {
        //-------实例化面板
        Type type = typeof(T);
        //如果打开了，就不执行打开方法
        if (m_AllPanel.ContainsKey(type))
        {
            return;
        }
        UIBase uIBase = Activator.CreateInstance(type) as UIBase; //  new MainUIView（）
        GameObject uiPrefab = Resources.Load<GameObject>("Panel/"+ uIBase.path);    
        GameObject pan = GameObject.Instantiate(uiPrefab);
        //----------------------------

        //调用的uI初始化功能
        uIBase.Init(pan);

        pan.transform.SetParent(m_AllPanelObj[uIBase.m_type].transform);

        if (uIBase.m_type == UiType.常用)
        {
            List<Type> daishanchu = new List<Type>();

            //查找不童的界面
            foreach (var item in m_AllPanel)
            {
                if(item.Value.m_type == UiType.常用 && item.Key != type)
                {
                    daishanchu.Add(item.Key);
                }
            }
            for (int i = 0; i < daishanchu.Count; i++)
            {
                m_AllPanel[daishanchu[i]].Destroy();
                m_AllPanel.Remove(daishanchu[i]);
            }
        }
        //初始化面板位置信息
        pan.GetComponent<RectTransform>().localPosition = Vector3.zero;
        pan.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 0);
        pan.GetComponent<RectTransform>().localScale = Vector3.one;
        
        m_AllPanel.Add(type, uIBase);
    }

    //获取UI面板
    public T GetUIPanel<T>() where T : UIBase
    {
        Type type = typeof(T);
        if (m_AllPanel.ContainsKey(type))
        {
            return m_AllPanel[type] as T;
        }

        return null;
    }

    public void Close<T>()where T:UIBase
    {
        if (m_AllPanel.ContainsKey(typeof(T)))
        {
            m_AllPanel[typeof(T)].Destroy();

            m_AllPanel.Remove(typeof(T));
        }
    }
}
