using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene("LevelFirst");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
