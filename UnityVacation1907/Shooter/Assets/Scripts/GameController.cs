using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SoundController soundControl;
    public UIController UIControl;

    public BGScroller[] BGArr;
    public float BGScrollSpeed;

    public EnemyPool enemyPool;
    public AteroidPool asteroidPool;
    public Player player;

    public bool mbGameOver;

    public float SpawnZPos;
    public float SpawnXMin;
    public float SpawnXMax;
    public int AstSpawnCount;
    public int EnemySpawnCount;
    private Coroutine hazardRoutine;

    public int Score;

    void Start()
    {
        //when you save the Coroutine as routine, effective to use as switching on and off, like stop and enable
        hazardRoutine = StartCoroutine(SpawnHazard());
        for (int i = 0; i < BGArr.Length; i++) {
            BGArr[i].SetSpeed(BGScrollSpeed);
        }
        mbGameOver = false;
        UIControl.ShowStatus("");
        Score = 0;
        UIControl.ShowScore(Score);
    }


    public SoundController GetSoundController()
    {
        return soundControl;
    }

    public void AddScore(int amount) {
        Score += amount;
    }

    public void GameOver() {
        UIControl.ShowStatus("Game Over...");
        //stop the background
        for (int i = 0; i < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(0);
        }
        //stop enemy spawning
        StopCoroutine(hazardRoutine);    //when you put iEunumerator, it does not work so well instead use couroutin
        mbGameOver = true;
    }

    public void RestarGame() {
        UIControl.ShowStatus("");
        Score = 0;
        UIControl.ShowScore(Score);
        //enable background
        for (int i = 0; i < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(BGScrollSpeed);
        }
        //enable spawn enemy
        hazardRoutine = StartCoroutine(SpawnHazard());
        //enable player
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);

        mbGameOver = false;
    }

    private IEnumerator SpawnHazard()
    {
        int currentAstCount = AstSpawnCount;
        int currentEnemyCount = EnemySpawnCount;
        yield return new WaitForSeconds(3);

        while (true) {

            if (currentAstCount > 0 && currentEnemyCount > 0)
            {
                float randVal = Random.Range(0, 100f);
                if (randVal < 30) // enemy spawn
                {

                    EnemyController enemy = enemyPool.GetFromPool();

                    enemy.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                    currentEnemyCount--;
                }
                else {  // asteroid spawn

                    AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0, 3));

                    ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                    currentAstCount--;
                }
            }
            else if (currentAstCount > 0)
            {
                for (int i = 0; i < currentAstCount; i++)
                {

                    AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0, 3));

                    ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                }
                currentAstCount = 0;
            }
            else if (currentEnemyCount > 0)
            {
                for (int i = 0; i < currentEnemyCount; i++)
                {

                    EnemyController enemy = enemyPool.GetFromPool();

                    enemy.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax),
                                                         0,
                                                         SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                }
                currentEnemyCount = 0;
            }
            else
            {
                currentAstCount = AstSpawnCount;
                currentEnemyCount = EnemySpawnCount;
                yield return new WaitForSeconds(3);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && mbGameOver) {
            RestarGame();
        }
    }
}