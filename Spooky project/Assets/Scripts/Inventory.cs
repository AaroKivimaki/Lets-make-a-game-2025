using UnityEngine;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    [SerializeField] private List<int> avainIds = new List<int>();

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LisaaAvain(AvainToiminto avain)
    {
        if (!avainIds.Contains(avain.id))
        {
            avainIds.Add(avain.id);
            Debug.Log($"avain lisätty: {avain.avainNimi} (ID: {avain.id})");
            UImanager.Instance.AddKeyToUI(avain);
        }
    }

    public bool OnAvain(AvainToiminto avain)
    {
        return avainIds.Contains(avain.id);
    }
}
