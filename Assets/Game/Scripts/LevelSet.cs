using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSet : MonoBehaviour
{

    public int[][] table;
    public float[,] levelTable;
    public int level;
    public int difficulty;
    public GameObject[] enemies;
    public GameObject spawn;
    private Vector3 randomLocation;
    private int enemycloneNameEnum;
    
    


    // Use this for initialization
    void Start()
    {

        switch (level)
        {
            case 1:
                levelOne();
                Debug.Log("Level One Loaded");
                break;
            case 2:
                Debug.Log("Level Two Loaded");
                break;
        }
    }
    public void levelOne()
    {
        float[,] levelTable = new float[3, 3];
        //Rows: Wave; SpeedMod; EnemyList
        //W1
        levelTable[0, 0] = 1;
        levelTable[0, 1] = 1;
        levelTable[0, 2] = 1;
        //W2
        levelTable[1, 2] = 2;
        levelTable[1, 1] = 1.1f;
        levelTable[1, 2] = 2;
        //W3
        levelTable[2, 0] = 3;
        levelTable[2, 1] = 1.2f;
        levelTable[2, 2] = 3;

        playLevel(levelTable, true);
    }

    public void playLevel(float[,] _levelTable, bool _play)
    {
        float wave = 0f;
        float speedMod = 0f;
        float enemyList = 0f;
        int count = 0;

        //	if (_play) 
        {
            for (int row = 0; row < _levelTable.GetLength(0); row++)
            {
                for (int col = 0; col < _levelTable.GetLength(1); col++)
                {
                    float s = _levelTable[row, col];


                    switch (col)
                    {
                        case 0://WAVE
                            Debug.Log("Wave " + s);
                            wave = s;
                            count++;
                            break;
                        case 1://SPEEDMOD
                            Debug.Log("SPEEDMOD " + s);
                            speedMod = s;
                            count++;
                            break;
                        case 2://EnemyList
                            Debug.Log("EnemyList " + s);
                            enemyList = s;
                            count++;
                            break;
                    }
                    if (count == 3)
                    {
                        levelInit(wave, speedMod, enemyList);
                        count = 0;
                    }
                }
            }
        }
    }

    void levelInit(float wave, float speedMod, float enemyList)
    {
        //Announce wave
        //Debug.Log ("wave " + wave);
        switch ((int)enemyList)
        {
            case 1:
               StartCoroutine((waveSmallEnemy(speedMod, difficulty)));//;
                
                Debug.Log("sml");
                break;
            case 2:
                waveLargeEnemy(speedMod, difficulty);
                Debug.Log("lrg");
                break;
            case 3:
                waveLargeFlyer(speedMod, difficulty);
                Debug.Log("flyr");
                break;
        }

    }

    IEnumerator waveLargeFlyer(float _speedMod, int _difficulty)
    {
        //release 5 large flyers
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.8f / _speedMod);
            Instantiate(enemies[2], spawn.transform.position, spawn.transform.rotation);
            Debug.Log("Done Flyer" + i);
        }
        yield return new WaitForSeconds(5 / _speedMod);



    }
    IEnumerator waveSmallEnemy(float _speedMod, int _difficulty)
    {
        //release 10 small enemies
        for (int i = 0; i < 10; i++) {
            randomLocation = Random.insideUnitSphere;
            randomLocation.x += spawn.gameObject.transform.position.x;
            randomLocation.y += spawn.gameObject.transform.position.y;
            randomLocation.z = spawn.gameObject.transform.position.z;
            Spawn(randomLocation);
            enemycloneNameEnum++;
        yield return new WaitForSeconds(0.5f * _speedMod);
    }
        Debug.Log("Done small");

    }
    IEnumerator waveLargeEnemy(float _speedMod, int _difficulty)
    {
        //release 1 Large enemy
        yield return new WaitForSeconds(0.5f * _speedMod);

        Instantiate(enemies[1], spawn.gameObject.transform.position, spawn.gameObject.transform.rotation);
        Debug.Log("Done Large");

    }

    void Spawn(Vector3 _randomLocation)
    {
        Object enemyClone;
       enemyClone = Instantiate(enemies[0], _randomLocation, spawn.gameObject.transform.rotation);
       enemyClone.name = "Enemy" + enemycloneNameEnum;
    }// Update is called once per frame
    

    void Update()
    {


    }
}
