using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBow : MonoBehaviour, IWeapon
{
    [Tooltip("Flèche associée")][SerializeField]
    private Arrow m_arrow;

    public void Attack(Transform p_originTransform, Transform p_targetTransform)
    {
        //dir = p_targetTransform.position - p_originTransform.position;
        //m_arrow.transform.position = p_originTransform.position;

        m_arrow.Throw(p_originTransform, p_targetTransform);
        
        Debug.Log("atk");
    }

    public void AttackSpecial(Transform p_originTransform, Transform p_targetTransform)
    {
        Debug.Log("atkSpe");
    }
}
