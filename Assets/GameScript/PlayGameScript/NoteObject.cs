using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public bool isSuccess;
    public KeyCode keyToPress;

    public GameObject hitEffect;
    public GameObject greatEffect;
    public GameObject prefectEffect;
    public GameObject missEffect;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            isSuccess = true;
            gameObject.SetActive(false);
            Destroy(gameObject, 1.5f);
            if (Mathf.Abs(transform.position.y - 1.0f) > 0.25f)
            {
                GameManager.instance.NormalHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
            else if (Mathf.Abs(transform.position.y - 1.0f) > 0.10f)
            {
                GameManager.instance.GreatHit();
                Instantiate(greatEffect, transform.position, greatEffect.transform.rotation);
            }
            else
            {
                GameManager.instance.PerfectHit();
                Instantiate(prefectEffect, transform.position, prefectEffect.transform.rotation);
            }
            
        }
        
    }

    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
            if (!isSuccess)
            {
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
        Destroy(gameObject, 1.5f);
    }

}
