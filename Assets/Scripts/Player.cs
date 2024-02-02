using System;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class Player: MonoBehaviour
{
   public static bool isMoveing = false;
    public static event Action moveUnit;

    public static void Ok()
    {
        moveUnit?.Invoke();
    }
}
