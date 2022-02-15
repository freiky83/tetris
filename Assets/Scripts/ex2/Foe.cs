using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe : MonoBehaviour, IEnnemi
{
    public float m_speed { get => m_speed;
        set { m_speed = value; }
    }
    public int m_life { get => m_life;
        set { m_life = value; }
    }
    public bool m_onFire { get => m_onFire;
        set { m_onFire = value; }
    }
    public Transform m_transform { get => transform;
        set { m_transform = value; }
    }
    public void Death()
    {
        if (m_life <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
