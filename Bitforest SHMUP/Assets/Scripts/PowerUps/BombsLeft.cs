using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombsLeft : MonoBehaviour
{
    public int startingBombs = 0;
    public int maxBombs;

    public Image bombImage_1, bombImage_2, bombImage_3;
    public Sprite bombSprite;
    public Sprite emptyBombSprite;
    public GameObject ObjectToSpawn;

    private int bombsOwned;

    // Start is called before the first frame update
    void Start()
    {
        bombsOwned = startingBombs;
    }

    public int GetBombs() { return bombsOwned; }
    public void AddBomb()
    {
        bombsOwned++;

        if (bombsOwned > maxBombs) { bombsOwned = maxBombs; }   // Do not add more than max bombs

        SetBombSprites();                                   // Update Sprites
    }
    public void UseBomb()
    {
        if (bombsOwned >= 1)
        {
            bombsOwned--;

            if (bombsOwned <= 0) { bombsOwned = 0; }        // Ensure no negative bombs
            SetBombSprites();                               // Update number of bomb sprites
            DestroyAllEnemies();
        }
        else { return; }                                    // No bombs exits
    }
    // Update bomb sprites
    public void SetBombSprites()
    {
        int currentBombs = GetBombs();

        if (currentBombs == 0)
        {
            bombImage_1.sprite = emptyBombSprite;
            bombImage_2.sprite = emptyBombSprite;
            bombImage_3.sprite = emptyBombSprite;
        }
        if (currentBombs == 1)
        {
            bombImage_1.sprite = bombSprite;
            bombImage_2.sprite = emptyBombSprite;
            bombImage_3.sprite = emptyBombSprite;
        }
        if (currentBombs == 2)
        {
            bombImage_1.sprite = bombSprite;
            bombImage_2.sprite = bombSprite;
            bombImage_3.sprite = emptyBombSprite;
        }
        if (currentBombs == 3)
        {
            bombImage_1.sprite = bombSprite;
            bombImage_2.sprite = bombSprite;
            bombImage_3.sprite = bombSprite;
        }
    }

    void DestroyAllEnemies()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < enemies.Length; i++)
        {
            Transform enemyPos = enemies[i].transform;
            Instantiate(ObjectToSpawn, enemyPos.position, enemyPos.rotation);
            Destroy(enemies[i]);
        }
    }
}
