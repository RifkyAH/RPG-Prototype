using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
public class MainMenuManager : MonoBehaviour
{
    [Inject]private LaunchSceneController _launch;
    [SerializeField]private GameObject MainMenu,OptionMenu,CreditMenu;
    public void StartButton()
    {
        MainThreadDispatcher.StartCoroutine(_launch.LoadMainScene());
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenuScene"));
    }
    public void OptionButton()
    {
        MainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }
}
