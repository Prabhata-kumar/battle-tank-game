using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceEvents : SingletonGenerics<ServiceEvents>
{
    public static event Action OnPlayerDeath;

    public static event Action OnGameLoaded;
    public static event Action OnGameStarted;
    public static event Action OnGamePaused;
    public static event Action OnGameEnded;
    public static event Action OnGameFailed;

    public static event Action<int> OnPurchaseSuccess;
    public static event Action<int> OnPurchaseFailed;
    public static event Action<int> OnPurchaseCancelled;

}
