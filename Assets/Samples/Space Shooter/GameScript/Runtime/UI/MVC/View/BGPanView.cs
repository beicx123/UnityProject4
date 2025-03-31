using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGPanView : UIBase
{
    BGController bgController;

    public BGPanView() : base("BGUIManager", UiType.¹Ì¶¨)
    {
    }

    public override void Init(GameObject gameobj)
    {
        base.Init(gameobj);
        bgController = gameobj.GetComponent<BGController>();
        Button shopBtn = gameobj.transform.Find("ShopBtn").GetComponent<Button>();
        shopBtn.onClick.AddListener(() =>
        {
            bgController.OpenShop();
        });
        Button bagBtn = gameobj.transform.Find("BagBtn").GetComponent<Button>();
        bagBtn.onClick.AddListener(() =>
        {
            bgController.OpenBag();
        });
        Button tipBtn = gameobj.transform.Find("TipBtn").GetComponent<Button>();
        tipBtn.onClick.AddListener(() =>
        {
            bgController.OpenTip();
        });
    }
}
