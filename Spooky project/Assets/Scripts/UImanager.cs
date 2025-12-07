using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class UImanager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Transform keyPanel;
    [SerializeField] private GameObject keyImagePrefab;

    private Dictionary<AvainToiminto, GameObject> keyImages = new Dictionary<AvainToiminto, GameObject>();
    public static UImanager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKeyToUI(AvainToiminto avain)
    {
        if (!keyImages.ContainsKey(avain))
        {
            GameObject keyImage = Instantiate(keyImagePrefab, keyPanel);
            keyImage.GetComponent<Image>().sprite = avain.avainSprite;
            keyImages[avain] = keyImage;
        }
    }
}
