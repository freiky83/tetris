using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Tooltip("Vitesse de la balle")][SerializeField]
    private float m_speed = 1f;

    [Tooltip("Dégats de la balle")][SerializeField]
    private int m_damage = 1;

    private bool m_hasHit = false;
    
    private IEnnemi m_target;
    private Transform m_targetTransform;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Throw(Transform p_originTransform, IEnnemi p_target)
    {
        gameObject.SetActive(true); // visible + active update
        transform.position = p_originTransform.position; // position du joueur

        m_target = p_target;
        m_hasHit = false;
        //Debug.Log(p_target.m_transform);
        
        transform.LookAt(m_target.m_transform);
    }

    public void Update()
    {
        MoveToTarget();
        //HitTarget();
    }

    private void MoveToTarget()
    {
        transform.position += transform.forward * Time.deltaTime * m_speed;
    }

    private void HitTarget()
    {
        if (!m_hasHit && (transform.position.x - m_target.m_transform.position.x < 1f) &&
            (transform.position.z - m_target.m_transform.position.z < 1f))
        {
            m_hasHit = true;
            //gameObject.SetActive(false);
            //m_target.m_life -= m_damage;
        }
    }
}

// index tournant i = i++ % length tableau