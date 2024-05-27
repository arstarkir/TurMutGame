using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkButtons : MonoBehaviour
{
    [SerializeField] GameObject sideSelect;
    bool asHost;
    public void OnHostBtnClick()
    {
        asHost = true;
        sideSelect.SetActive(!sideSelect.active);
    }
    public void OnClientBtnClick()
    {
        asHost = false;
        sideSelect.SetActive(!sideSelect.active);
    }
    public void OnClickStartUkr()
    {
        if(asHost)
            NetworkManager.Singleton.StartHost();
        else
            NetworkManager.Singleton.StartClient();
        sideSelect.SetActive(!sideSelect.active);
    }
    public void OnClickStartRus()
    {
        if (asHost)
            NetworkManager.Singleton.StartHost();
        else
            NetworkManager.Singleton.StartClient();
        sideSelect.SetActive(!sideSelect.active);
    }

}
