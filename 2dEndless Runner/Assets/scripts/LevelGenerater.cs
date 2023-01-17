using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerater : MonoBehaviour
{
    public Transform LevelObj;
    public Transform LevelStart;

    private Vector3 Level_End_Pos;
    public Player player;

    public float DistanceBetween_Level=200f;
    // Start is called before the first frame update
    void Awake()
    {
        Level_End_Pos = LevelStart.Find("EndPos").position;
        SpawnLevel();
/*        int levelpartnum = 5;
        for (int i = 0; i < levelpartnum; i++)
        {
            SpawnLevel();
        }*/
    }
    void SpawnLevel()
    {
        Transform Level_Part_End= SpawnLevelPart(Level_End_Pos);
        Level_End_Pos = Level_Part_End.Find("EndPos").position;
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, Level_End_Pos) < DistanceBetween_Level)
        {
            SpawnLevel();
        }
    }

    private Transform SpawnLevelPart(Vector3 pos)
    {
        Transform Level_Part_Start=Instantiate(LevelObj, pos, Quaternion.identity);
        return Level_Part_Start;
    }
}
