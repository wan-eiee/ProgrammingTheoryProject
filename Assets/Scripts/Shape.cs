using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public abstract class Shape : MonoBehaviour
{
    [SerializeField]
    protected TextMeshPro nameText;
    private float speed = 10.0f;
    // ENCAPSULATION
    public string shapeName{get; private set;}
    public Color color{get; private set;}


    // ABSTRACTION
    protected virtual void OnClicked(string tagName){
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.collider.CompareTag(tag)){
                hit.rigidbody.AddForce(Vector3.up * speed, ForceMode.Impulse);
                DisplayText();
                OwnMethod();
            }
        }
    }

    protected abstract void OwnMethod();


    // ABSTRACTION
    protected virtual void DisplayText(){
        nameText.enabled = true;
        nameText.text = shapeName;
        Debug.Log(shapeName);
    }

    protected void SetName(string paramName){
        shapeName = paramName;
    }

    protected void SetColor(Color paramColor){
        color = paramColor;
    }

    private void OnCollisionEnter(Collision coll){
        if(coll.collider.CompareTag("Ground")){
            nameText.enabled = false;
        }
    }
}
