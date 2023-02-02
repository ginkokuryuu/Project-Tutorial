using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledCounter : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text enemyKilledText = null;
    int enemyKilled = 0;

    void EnemyKilled()
    {
        enemyKilled += 1;
        enemyKilledText.text = enemyKilled.ToString("00");
    }
}
