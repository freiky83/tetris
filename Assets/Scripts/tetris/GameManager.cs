using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    [SerializeField, Tooltip("Prefab du Cube")]
    private GameObject m_cubePrefab;

    private float m_elapsedTime = 0;
    private float m_timerMove = 0;

    [SerializeField, Tooltip("X, Y")] private int m_boardWidth = 8;
    [SerializeField, Tooltip("X, Y")] private int m_boardHeight = 25;

    [SerializeField, Tooltip("Vitesse de descente")]
    private float m_tickRate = 1;

    [SerializeField, Tooltip("Vitesse de translation")]
    private float m_moveRate = 0.1f;

    private Cube m_cubeInstance;
    private List<Cube> m_cubes = new List<Cube>();

    public delegate void MoveDelegate();

    public delegate void DeleteLineDelegate(int p_y);

    public MoveDelegate OnMove;
    //public MoveDelegate onInputMove; // peut se faire pour le déplacement horizontal

    public DeleteLineDelegate OnDeleteLine;

    public enum Status
    {
        VIDE = 0,
        PLEINE = 1,
        ERROR = 10
    }

    private Status[,] m_board;

    private void Start()
    {
        ClearBoard();
        CreateCube();
    }

    private void Update()
    {
        // si le temps est écoulé, on fait descendre la brique courante
        m_timerMove += Time.deltaTime;
        if (m_timerMove >= m_moveRate)
        {
            MoveHorizontal();
            m_timerMove = 0;
        }

        m_elapsedTime += Time.deltaTime;
        if (m_elapsedTime >= m_tickRate)
        {
            //MoveDown();
            OnMove?.Invoke(); // ?. si OnMove n'est pas nul (appel de manière propre)
            m_elapsedTime = 0;
        }
    }

    private void ClearBoard()
    {
        m_board = new Status[m_boardWidth, m_boardHeight];
        m_cubes.Clear();
    }

    protected override string GetSingletonName()
    {
        return "GameManager";
    }

    private void MoveDown()
    {
        // Déplacer la pièce courante vers le bas
        for (int i = 0; i < m_cubes.Count; i++)
        {
            //m_cubes[i].MoveDown();
        }
    }

    private void MoveHorizontal()
    {
        int horizontal = (int) Input.GetAxisRaw("Horizontal");
        m_cubeInstance.MoveHorizontal(horizontal);
    }

    public void CreateCube()
    {
        int xPos = Random.Range(0, m_boardWidth);

        if (m_board[xPos, m_boardHeight - 1] == Status.PLEINE)
        {
            // GameOver
            Debug.Log("Le jeu est terminé");
            return;
        }

        m_board[xPos, m_boardHeight - 1] = Status.PLEINE;

        Vector3 cubePos = new Vector3(xPos, m_boardHeight - 1, 0);
        GameObject go = Instantiate(m_cubePrefab, cubePos, Quaternion.identity);
        Cube cube = go.GetComponent<Cube>();
        cube.SetPositions(xPos, m_boardHeight - 1);

        m_cubeInstance = cube;
        m_cubes.Add(cube);
    }

    public Status GetStatus(int p_x, int p_y)
    {
        if (p_x < 0 || p_x >= m_boardWidth || p_y < 0 || p_y >= m_boardHeight)
        {
            Debug.LogError("La position n'existe pas");
            return Status.ERROR;
        }

        Status debugStat = m_board[p_x, p_y];
        //Debug.Log($"position x{p_x}, position y{p_y}, = {m_board[p_x,p_y]}");
        return m_board[p_x, p_y];
    }

    public void MoveCube(int p_xOrigin, int p_yOrigin, int p_xDest, int p_yDest)
    {
        // Mettre les sécurités

        // Libère l'ancienne position et rempli la position de la destination
        m_board[p_xOrigin, p_yOrigin] = Status.VIDE;
        m_board[p_xDest, p_yDest] = Status.PLEINE;
    }

    public void CheckLine(int p_y)
    {
        // verif ligne pleine
        for (int i = 0; i < m_boardWidth; i++)
        {
            if (m_board[i, p_y] == Status.VIDE) return;
        }

        // clean ligne pleine (visuel + board)
    }

    public void DeleteCube(int p_xPos, int p_yPos)
    {
        m_board[p_xPos, p_yPos] = Status.VIDE;
    }
}