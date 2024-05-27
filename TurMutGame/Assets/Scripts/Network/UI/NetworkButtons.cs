using UnityEngine;

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
        if (asHost)
            CustomNetworkManager.instance.CustomStartHost("Ukr");
        else
            CustomNetworkManager.instance.CustomStartClient("Ukr");
        sideSelect.SetActive(!sideSelect.active);
    }
    public void OnClickStartRus()
    {
        if (asHost)
            CustomNetworkManager.instance.CustomStartHost("Rus");
        else
            CustomNetworkManager.instance.CustomStartClient("Rus");
        sideSelect.SetActive(!sideSelect.active);
    }

}
