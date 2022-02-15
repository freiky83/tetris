using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Vitesse du joueur")][SerializeField]
    private float m_speed = 0.1f;

    [Tooltip("Force de saut")][SerializeField]
    private float m_jumpForce = 300f;

    [SerializeField] 
    private Rigidbody m_rb;

    [SerializeField] 
    private IWeapon m_weapon;
    
    [SerializeField] 
    private Foe foe;

    [Tooltip("Caméra 3eme personne")][SerializeField]
    private Camera mainCam;
    
    private void Start()
    {
        m_weapon = GetComponent<IWeapon>();
    }

    public void Update()
    {
        Deplacement();
        Action();
    }

    private void Deplacement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        //rb.AddForce(new Vector3(horizontal, 0f, vertical) * m_speed);
        this.transform.position += new Vector3(horizontal, 0f, vertical) * m_speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rb.AddForce(0f, m_jumpForce, 0f);
        }
    }

    private void Action()
    {
        // ATTACK 1
        if(Input.GetKeyDown(KeyCode.A)) m_weapon.Attack(this.transform, foe.transform);
        // ATTACK 2
        if(Input.GetKeyDown(KeyCode.E)) m_weapon.AttackSpecial(this.transform, foe.transform);
    }

}
