using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBow : MonoBehaviour, IWeapon
{
    [Tooltip("Flèche associée")][SerializeField]
    private Arrow m_arrow;

    public void Attack(Transform p_originTransform, IEnnemi p_target)
    {
        m_arrow.Throw(p_originTransform, p_target);
        
        Debug.Log("atk");
    }

    public void AttackSpecial(Transform p_originTransform, IEnnemi p_target)
    {
        Debug.Log("atkSpe");
    }
}
