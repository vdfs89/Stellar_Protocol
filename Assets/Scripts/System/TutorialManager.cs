using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private int step = 0;

    void Start()
    {
        ShowStep();
    }

    void ShowStep()
    {
        switch (step)
        {
            case 0:
                Debug.Log("Tutorial: Use A/D to move.");
                break;
            case 1:
                Debug.Log("Tutorial: Press SPACE to shoot.");
                break;
            default:
                Debug.Log("Tutorial complete!");
                AnalyticsManager.LogEvent("tutorial_complete");
                ProgressionManager.Instance?.UnlockLevel("Level1");
                break;
        }
    }

    public void NextStep()
    {
        step++;
        ShowStep();
    }
}
