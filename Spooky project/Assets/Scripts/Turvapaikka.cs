using UnityEngine;

public class Turvapaikka : MonoBehaviour
{
    public Material vari;
    public Color myColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = vari;
        myColor = new Color(0, 0, 0, 0);
        vari.color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
