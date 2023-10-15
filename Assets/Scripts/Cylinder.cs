using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class Cylinder : Shape // INHERITANCE
{
    private string myName = "Cylinder";
    private Color myColor;
    private Vector3 initPos;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        initPos = transform.position;
        myColor = GetComponent<Renderer>().material.color;
        SetName(myName);
        SetColor(myColor);
    }

    // Update is called once per frame
    void Update()
    {
        OnClicked(tag);
    }

    // POLYMORPHISM
    /// <summary>
    /// animate gameObject
    /// </summary>
    protected override void OwnMethod(){
        anim.SetTrigger("rotateTrigger");
        anim.SetBool("isGrounded", false);
    }

    private void OnCollisionEnter(Collision coll){
        if(coll.collider.CompareTag("Ground")){
            nameText.enabled = false;
            anim.SetBool("isGrounded", true);
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.position = initPos;
            rb.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
        }
    }
}
