using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TimerUI timerUI;

    public TimerUI GetTimerUI { get => timerUI; }
}
