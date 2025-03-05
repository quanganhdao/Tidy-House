using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAction : MonoBehaviour
{
    public void GoToStore()
    {
        Luna.Unity.LifeCycle.GameEnded();
        Luna.Unity.Playable.InstallFullGame();
    }
}
