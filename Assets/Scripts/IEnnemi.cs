using UnityEngine;

public interface IEnnemi
{
    float m_speed { get; set; }
    int m_life { get; set; }
    bool m_onFire { get; set; }

    Transform m_transform { get; set; }
    public void Death();
}
