using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreManager : MonoBehaviour
{
    public void UpdateScoreText()
    {
        Text score = GetComponent<Text>();
        score.text ="Score : "+ GameManager.Instance.enemykilledScore;
    }
}
