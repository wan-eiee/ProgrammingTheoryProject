using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Cube : Shape // INHERITANCE
{
    private string myName = "Cube";
    private Material material;
    private Color initColor;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        initColor = material.color;
        SetName(myName);
        SetColor(initColor);
    }

    // Update is called once per frame
    void Update()
    {
        OnClicked(tag);
    }

    // POLYMORPHISM
    /// <summary>
    /// change color
    /// </summary>
    protected override void OwnMethod(){
        float red = Random.Range(0.0f, 1.0f);
        float green = Random.Range(0.0f, 1.0f);
        float blue = Random.Range(0.0f, 1.0f);
        var color = new Color(red, green, blue);
        material.color = color;
        //material.SetColor("_Color", color);
        SetColor(color);
    }

    private void OnDestroy(){
        SetColor(initColor);
    }
}
