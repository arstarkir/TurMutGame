using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkButtons : MonoBehaviour
{
    bool asHost;
    public void OnHostBtnClick(GameObject gameObject)
    {
        asHost = true;
        gameObject.SetActive(!gameObject.active);
    }
    public void OnClientBtnClick(GameObject gameObject)
    {
        asHost = false;
        gameObject.SetActive(!gameObject.active);
    }
    public void OnClickStartUkr()
    {
        if(asHost)
            NetworkManager.Singleton.StartHost();
        else
            NetworkManager.Singleton.StartClient();
    }
    public void OnClickStartRus()
    {
        if (asHost)
            NetworkManager.Singleton.StartHost();
        else
            NetworkManager.Singleton.StartClient();
    }

}
