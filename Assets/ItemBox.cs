using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool isOverapped = false;
    private Renderer myRenderer;
    private Color originalColor;

    public Color touchColor;


    // Start is called before the first frame update
    void Start()
    {
        this.myRenderer = this.GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EndPoint")
        {
            isOverapped = true;
            myRenderer.material.color = touchColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "EndPoint")
        {
            isOverapped = false;
            myRenderer.material.color = originalColor;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "EndPoint")
        {
            isOverapped = true;
            myRenderer.material.color = touchColor;
        }
    }
}
