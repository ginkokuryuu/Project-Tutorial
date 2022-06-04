using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text goldText = null;
    int gold = 0;


    void EnemyKilled()
    {
        gold += 1;
        goldText.text = gold.ToString("00");
    }
}
