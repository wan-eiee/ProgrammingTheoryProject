using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sphere : Shape // INHERITANCE
{
    private string myName = "Sphere";
    private Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        myColor = GetComponent<Renderer>().material.color;
        SetName(myName);
        SetColor(myColor);
    }

    // Update is called once per frame
    void Update()
    {
        OnClicked(tag);
    }

    private void ChangeColor(){
        var rand = Random.Range(0, 1.0f);
        var mat = GetComponent<Renderer>().material;
        mat.color = new Color(rand, rand, rand);
    }

    // POLYMORPHISM
    protected override void OwnMethod(){
        int rand = Random.Range(0, 3);
        switch(rand){
            case 0:
                myName = "SPHERE";
                break;
            case 1:
                myName = "SpherE";
                break;
            case 2:
                myName = "Sphere";
                break;
        }
        SetName(myName);
    }
}
