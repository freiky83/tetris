using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI m_text;
    private int m_score;
    public void Start()
    {
        m_text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Cube.onScore += HandleScore;
    }

    private void OnDisable()
    {
        Cube.onScore -= HandleScore;
    }

    private void HandleScore(int p_score)
    {
        m_score += p_score;
        m_text.text = $"{m_score}";
    }
    
    /*
     * Afficher le score
     * Effacer les lignes
     * Tourner les pièces
     * (Faire un système de couleur pour terminer une ligne)
     */
}
