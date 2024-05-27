using Unity.Netcode;
using UnityEngine;

public class TeamView : NetworkBehaviour
{

    void TeamAssign(string tag)
    {
        if(gameObject.TryGetComponent<PlayerTeam>(out PlayerTeam pt))
        {
            gameObject.tag = tag;
            if (tag == "Ukr")
                pt.isUkr = true;
            else
                pt.isUkr = false;
        }
        NewPlayerJoin();
    }

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
        CustomNetworkManager.instance.OnStarting += TeamAssign;
    }
    private void OnDisable()
    {
        CustomNetworkManager.instance.OnStarting -= TeamAssign;
    }
}
