using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TMP_Text titleText;
    public TMP_Text currentTimeText;

    public AudioSource audioSource;
    public AudioClip winSound;
    public AudioClip loseSound;

    private bool panelShown = false;

    void Start()
    {
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!GameController.gameOver)
        {
            if (currentTimeText != null)
            {
                currentTimeText.text = "Tempo: " + Mathf.CeilToInt(GameController.TimeLeft) + "s";
            }
        }

        if (!panelShown && GameController.gameOver)
        {
            panelShown = true;

            if (currentTimeText != null)
            {
                currentTimeText.gameObject.SetActive(false);
            }

            GameObject music = GameObject.Find("Music");
            if (music != null)
            {
                AudioSource musicSource = music.GetComponent<AudioSource>();
                if (musicSource != null)
                {
                    musicSource.Stop();
                }
            }

            if (endGamePanel != null)
            {
                endGamePanel.SetActive(true);
            }

            if (GameController.playerWon)
            {
                if (titleText != null)
                {
                    titleText.text = "VOCE VENCEU!";
                }

                if (audioSource != null && winSound != null)
                {
                    audioSource.PlayOneShot(winSound);
                }
            }
            else
            {
                if (titleText != null)
                {
                    titleText.text = "GAME OVER";
                }

                if (audioSource != null && loseSound != null)
                {
                    audioSource.PlayOneShot(loseSound);
                }
            }
        }
    }
}