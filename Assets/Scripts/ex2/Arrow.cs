using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float m_speed = 1f;
    
    private Transform m_targetTransform;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Throw(Transform p_originTransform, Transform p_targetTransform)
    {
        gameObject.SetActive(true);
        transform.position = p_originTransform.position;
        transform.LookAt(p_targetTransform);
        m_targetTransform = p_targetTransform;
    }

    public void Update()
    {
       transform.position += transform.forward * Time.deltaTime * m_speed;
       
       if(Mathf.Approximately(transform.position.x,m_targetTransform.position.x) && Mathf.Approximately(transform.position.z,m_targetTransform.position.z)) gameObject.SetActive(false);
    }
}

// index tournant i = i++ % length tableau