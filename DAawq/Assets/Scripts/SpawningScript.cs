using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{

    List<string> Waves = new List<string>();
    List<string> list = new List<string>();
    public GameObject Normal;
    public GameObject Healer;
    public GameObject Chonk;
    public float timer = 10;
    public float maxTimer = 10;
    private void Start()
    {
        Waves.Add("1 Normal");
        Waves.Add("1 Normal");
        Waves.Add("1 Normal");
        Waves.Add("1 Chonk;");
        Waves.Add("5 Normal; 3 Chonk;5 Normal"); //5
        Waves.Add("1 Chonk;1 Healer;1 Chonk");
        Waves.Add("1 Chonk;1 Healer;3 Normal");
        Waves.Add("1 Chonk;1 Healer;15 Normal");
        Waves.Add("3 Chonk;1 Healer;10 Normal;1 Healer");

    }

    void Update()
    {
        
        if (timer > 0)
        {
            timer -= 0.1f;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && Waves.Count != 0)
        {
            string[] instructions = Waves[0].Split(';');
            Debug.Log(instructions[0]);
            Waves.RemoveAt(0);
            for (int i = 0; i < instructions.Length; i++)
            {
                string[] enemies = instructions[i].Split(' ');
                for (int p = 0; p < int.Parse(enemies[0]); p++)
                {
                    list.Add(enemies[1]);
                }
            }
        }

        if (timer <= 0 && list.Count > 0)
        {
            if (list[0] == "Normal")
            {
                Instantiate(Normal, this.transform.position, Quaternion.identity);
                list.RemoveAt(0);
            }
            if (list[0] == "Healer")
            {
                Instantiate(Healer, this.transform.position, Quaternion.identity);
                list.RemoveAt(0);
            }
            if (list[0] == "Chonk")
            {
                Instantiate(Chonk, this.transform.position, Quaternion.identity);
                list.RemoveAt(0);
            }
        }

        if (timer < 0)
        {
            timer = maxTimer;
        }

        if (Waves.Count == 0)
        {
            Application.Quit();
        }
    }
}
