using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void IniciaJogo()
    {
        GameController.Init(4, 10f);
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}