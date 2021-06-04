using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifetime;
    void Start()
    {
        lifetime = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lifetime);
    }
}
