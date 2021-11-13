using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public int playerHealth;
    public int money;
    public int score;

    [SerializeField]
    TextMeshProUGUI textObj;

    private void Start()
    {
        textObj.text = playerHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        textObj.text = playerHealth.ToString();
    }
}
