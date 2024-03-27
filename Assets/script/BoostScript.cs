using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    public float velX = 5f;
    float velY= 0f;
    Rigidbody2D rb;
    public float lifeTime = 5f;

    void Awake()
    {
        Vector3 localScale = transform.localScale;
        if(velX < 0)
        {
            localScale.x *=-1;
            transform.localScale = localScale;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (velX, velY);
        Invoke("destroyGameobject",lifeTime);
    }

    void destroyGameobject()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<ParticleSystem>().Stop ();
            Destroy (child.gameObject, 3f);
        }
        transform.DetachChildren ();
        Destroy (gameObject);
    }
}
