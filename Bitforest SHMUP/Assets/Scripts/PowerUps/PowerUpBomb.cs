using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLO
{
    public class PowerUpBomb : AppResourceMonoBehaviour
    {
        public BombsLeft bombsLeft;
        public GameObject Projectile;

        private void Start()
        {
            bombsLeft = FindObjectOfType<BombsLeft>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            bombsLeft.AddBomb();
            Destroy(gameObject);
        }
    }
}