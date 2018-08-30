using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreSetter : MonoBehaviour
{
    public SceneScoreManager sceneScoreManager;
    public int scoreAmount = 10;

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy() => sceneScoreManager.IncrementScore(scoreAmount);
}
