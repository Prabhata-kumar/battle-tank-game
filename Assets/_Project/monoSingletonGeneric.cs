using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoSingletonGeneric<T> : MonoBehaviour where T : monoSingletonGeneric<T>
{
    private static T instance;

    public static T Instance { get { return instance; } }

    public void Awake()
    {
        Awake(Instance);
    }

    public void Awake(T instance)
    {
        if (Instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("some one trying to creat a duplicate singlton");
            Destroy(this);
        }
    }


   /* public class PlayerTank : monoSingletonGeneric<PlayerTank>
    {
        protected void Awake()
        {
            base.Awake();
            //playerTank awake functions
        }

        internal void StartGame()
        {
            Debug.Log("Player Start Game Function");
        }
    }

    public class EnemyTank : monoSingletonGeneric<EnemyTank>
    {
        private void Start()
        {
            PlayerTank.Instance.StartGame();
        }
    }*/

}
