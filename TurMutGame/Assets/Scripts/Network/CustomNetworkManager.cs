using System;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class CustomNetworkManager : MonoBehaviour
{
    public event Action<string> OnStarting = null;
    public static CustomNetworkManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    public bool CustomStartClient(string info)
    {
        bool result = NetworkManager.Singleton.StartClient();
        OnStarting?.Invoke(info);
        return result;
    }
    public bool CustomStartHost(string info)
    {
        bool result = NetworkManager.Singleton.StartHost();
        OnStarting?.Invoke(info);
        return result;
    }
}
