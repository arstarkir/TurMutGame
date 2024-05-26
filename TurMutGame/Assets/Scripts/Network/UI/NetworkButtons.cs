using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkButtons : MonoBehaviour
{
    public void OnHostBtnClick()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void OnClientBtnClick()
    {
        NetworkManager.Singleton.StartClient();
    }
}
