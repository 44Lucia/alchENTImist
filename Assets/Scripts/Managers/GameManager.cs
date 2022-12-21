using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField, Tooltip("Time in seconds")] private float timerTime;

    private void Update()
    {
        UIManager.Instance.GetTimerUI.gameObject.SetActive(true);

        StartCoroutine(Counter());
    }
    
    public IEnumerator Counter()
    {
        float time = timerTime;
        while (time > 0)
        {
            time -= Time.deltaTime;
            UIManager.Instance.GetTimerUI.setTimerTime(time);

            yield return null;
        }
    }
}
