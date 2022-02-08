using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Cube : MonoBehaviour
{
    private int m_cubePosX;
    private int m_cubePosY;

    private bool m_isLocked = false;
    
    public delegate void ScoreDelegate(int p_score);

    public static ScoreDelegate onScore;
    private void OnEnable()
    {
        GameManager.Instance.OnMove += HandleMove;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnMove -= HandleMove;
    }

    public void SetPositions(int p_x, int p_y)
    {
        //Debug.Log($"position du cube {p_x},{p_y}");
        m_cubePosX = p_x;
        m_cubePosY = p_y;
    }

    public void HandleMove()
    {

        if (m_isLocked)
        {
            Debug.Log("Le cube est bloqué, on l'ignore",this);
            //verifier si ligne du bas libre ?
            
            return;
        }
        //si la case en dessous est vide, descendre cube
        //si en bas du tableau
        //sinon lock cube
        
        if (m_cubePosY == 0 || GameManager.Instance.GetStatus(m_cubePosX, m_cubePosY - 1) == GameManager.Status.PLEINE)
        {
            Debug.Log("On bloque le cube",this);
            // on lock
            m_isLocked = true;
            onScore?.Invoke(10);
            GameManager.Instance.CreateCube();
            return;
        }
        
        //Debug.Log("Move du cube", this);
        GameManager.Instance.MoveCube(m_cubePosX, m_cubePosY, m_cubePosX, --m_cubePosY);
        transform.position = new Vector3(m_cubePosX, m_cubePosY, 0);
        SetPositions(m_cubePosX,m_cubePosY);
    }

    public void MoveHorizontal(int p_dx)
    {
        int posX = m_cubePosX + p_dx;
        
        if (GameManager.Instance.GetStatus(posX, m_cubePosY) == GameManager.Status.VIDE)
        {
            GameManager.Instance.MoveCube(m_cubePosX, m_cubePosY, posX, m_cubePosY);
            transform.position = new Vector3(posX, m_cubePosY, 0);
            SetPositions(posX,m_cubePosY);
        }
    }
}
