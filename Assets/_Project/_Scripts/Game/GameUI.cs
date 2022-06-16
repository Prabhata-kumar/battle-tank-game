using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameUI : SingletonGenerics<GameUI>
{
    public static event Action OnDeath;
    public static event Action OnDeathCount;
    public static event Action PlayerBulletFired;

    public GameObject playerKillUI;

    bool checkUI;
    public TMP_Text enemyTankKillCountUI;
    public TMP_Text PlayerBulletFiredCountUI;


  //  public int myID; //TankService thing

    private int enemyTankKillCount = 0;
    private int playerBulletFiredCount = 0;

    public GameObject TENBulletsfired;
    public GameObject T5Bulletsfired;
    public GameObject Enemies3Killed;

    private void Start()
    {
        playerKillUI.SetActive(false);
        checkUI = false;
    }
    private void Update()
    {
        OnDeath?.Invoke();
        OnDeathCount?.Invoke();
        PlayerBulletFired?.Invoke();
        CheckAchievementSystem();
    }
        
    public void GameUI_OnDeath()
    {
        if (!checkUI)
        {
            playerKillUI.SetActive(true);
            checkUI = true;
            StartCoroutine(ResetUIActive());
        }
    }
    private IEnumerator ResetUIActive()
    {
        yield return new WaitForSeconds(2f);
        checkUI = false;
        playerKillUI.SetActive(false);
        OnDeath -= GameUI_OnDeath;
    }
    public void GameUI_OnDeathCount()
    {
        enemyTankKillCount++;
        enemyTankKillCountUI.text = "Enemies Killed: " + enemyTankKillCount.ToString();
        OnDeathCount -= GameUI_OnDeathCount;
    }
    
    public void CheckUIBulletCount()
    {
        playerBulletFiredCount++;
        PlayerBulletFiredCountUI.text = "Bullets Fired: " + playerBulletFiredCount.ToString();
        PlayerBulletFired -= CheckUIBulletCount;
    }


    private void CheckAchievementSystem()
    {
        if (playerBulletFiredCount == 10)
        {
            TENBulletsfired.SetActive(true);
        }
        if(playerBulletFiredCount == 25)
        {
            T5Bulletsfired.SetActive(true);
        }
        if(enemyTankKillCount == 3)
        {
            Enemies3Killed.SetActive(true);
        }
    }
    private void OnDisable()
    {
        OnDeath -= GameUI_OnDeath;
        OnDeathCount -= GameUI_OnDeathCount;
    }

    public void RestartGame()
    {
        playerKillUI.SetActive(false);
        OnDeath -= GameUI_OnDeath;
        OnDeathCount -= GameUI_OnDeathCount;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


//Reference Script for future
/* 
  public event Action<int, int> onDeath;
  OnDeath = GameUI_OnDeath;
  onDeath += GameUI_onDeath;

    private void Start()
    {
        
        onDeath?.Invoke(0, 100);
    }

    //public void GameUI_onDeath(int deadTankID, int killedTankID)
    //{
    //    if (killedTankID == myID)
    //    {

    //    }
    //    else if(deadTankID == myID)
    //    {

    //    }
    //}

*/
