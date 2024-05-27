using Unity.Netcode;
using UnityEngine;

public class TeamView : NetworkBehaviour
{
    void NewPlayerJoin()
    {
        GameObject[] rus = GameObject.FindGameObjectsWithTag("Rus");
        GameObject[] ukr = GameObject.FindGameObjectsWithTag("Ukr");

        foreach (GameObject item in rus)
            if(!item.TryGetComponent<PlayerTeam>(out PlayerTeam pt))
                if(gameObject.GetComponent<PlayerTeam>().isUkr)
                    item.SetActive(false);

        foreach (GameObject item in ukr)
            if (!item.TryGetComponent<PlayerTeam>(out PlayerTeam pt))
                if (!gameObject.GetComponent<PlayerTeam>().isUkr)
                    item.SetActive(false);
    }
    private void OnEnable()
    {
        NetworkManager.Singleton.OnClientStarted += NewPlayerJoin;
    }
    private void OnDisable()
    {
        NetworkManager.Singleton.OnClientStarted -= NewPlayerJoin;
    }
}
