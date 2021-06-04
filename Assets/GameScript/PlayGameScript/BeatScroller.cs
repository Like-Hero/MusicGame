using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        speed = 120;
        speed /= 60f;
    }

    private void Update()
    {
        if (GameManager.hasStarted && !CompareTag("OriginArrow"))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
