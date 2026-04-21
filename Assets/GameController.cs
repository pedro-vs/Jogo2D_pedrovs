using UnityEngine;

public static class GameController
{
    private static int collectableCount;
    private static float timeLeft;
    private static float finalTime;
    private static bool started;
    private static bool won;

    public static bool gameOver
    {
        get { return started && (collectableCount <= 0 || timeLeft <= 0f); }
    }

    public static bool playerWon
    {
        get { return won; }
    }

    public static float TimeLeft
    {
        get { return timeLeft; }
    }

    public static float FinalTime
    {
        get { return finalTime; }
    }

    public static void Init(int totalCollectables = 4, float initialTime = 10f)
    {
        collectableCount = totalCollectables;
        timeLeft = initialTime;
        finalTime = 0f;
        started = true;
        won = false;
    }

    public static void Tick(float deltaTime)
    {
        if (!started || gameOver) return;

        timeLeft -= deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            finalTime = 0f;
            won = false;
        }
    }

    public static void Collect()
    {
        if (!started || gameOver) return;

        collectableCount--;

        if (collectableCount <= 0)
        {
            collectableCount = 0;
            finalTime = timeLeft;
            won = true;
        }
    }
}