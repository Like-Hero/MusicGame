using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressImage;

    public Animator anim;
    public KeyCode keyToPress;
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressImage;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
        
    }

}
