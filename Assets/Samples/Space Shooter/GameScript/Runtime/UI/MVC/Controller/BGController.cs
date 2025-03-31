using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    BGPanView bgPanView;
    // Start is called before the first frame update
    void Start()
    {
        bgPanView = UIManager.Instance.GetUIPanel<BGPanView>();
    }

    public void OpenShop()
    {
        UIManager.Instance.Open<ShopPanView>();
    }

    public void OpenBag()
    {
        UIManager.Instance.Open<BagPanView>();
    }

    public void OpenTip()
    {
        UIManager.Instance.Open<TipPanView>();
    }
}
