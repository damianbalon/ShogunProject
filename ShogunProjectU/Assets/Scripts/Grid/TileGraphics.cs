using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGraphics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void setAlpha(float a) {
        Color currentColor = gameObject.GetComponent<SpriteRenderer>().color;

        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, a);

        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }

    public void setColor(float r, float g, float b) {
        Color currentColor = gameObject.GetComponent<SpriteRenderer>().color;

        Color newColor = new Color(r, g, b, currentColor.a);

        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
    
    public void setColor(float r, float g, float b, float a) {
        Color currentColor = gameObject.GetComponent<SpriteRenderer>().color;

        Color newColor = new Color(r, g, b, a);

        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }      
}
