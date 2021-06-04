using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("toUp")) anim.SetBool("toUp", false);
        if (anim.GetBool("toDown")) anim.SetBool("toDown", false);
        if (anim.GetBool("toRight")) anim.SetBool("toRight", false);
        if (anim.GetBool("toLeft")) anim.SetBool("toLeft", false);

        if (Input.GetKey(KeyCode.UpArrow)) anim.SetBool("toUp", true);
        if (Input.GetKey(KeyCode.DownArrow)) anim.SetBool("toDown", true);
        if (Input.GetKey(KeyCode.RightArrow)) anim.SetBool("toRight", true);
        if (Input.GetKey(KeyCode.LeftArrow)) anim.SetBool("toLeft", true);
        
    }
}
