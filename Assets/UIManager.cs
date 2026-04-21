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
        endGamePanel.SetActive(false);
    }

    void Update()
    {
        if (!GameController.gameOver)
        {
            currentTimeText.text = "Tempo: " + Mathf.CeilToInt(GameController.TimeLeft) + "s";
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

            endGamePanel.SetActive(true);

            if (GameController.playerWon)
            {
                titleText.text = "VOCE VENCEU!";
                audioSource.PlayOneShot(winSound);
            }
            else
            {
                titleText.text = "GAME OVER";
                audioSource.PlayOneShot(loseSound);
            }
        }
    }
}