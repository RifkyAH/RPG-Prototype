using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using UniRx;

public class LaunchSceneController : IInitializable
{
    const string BOOT_SCENE = "BootScene";
    const string MAIN_SCENE = "MainScene";
    const string Over_World_Scene = "OverWorldScene";
    public void Initialize()
    {
        MainThreadDispatcher.StartCoroutine(LoadMainScene());
    }
    public IEnumerator LoadMainScene()
    {
        if (SceneManager.GetSceneByName(MAIN_SCENE).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(MAIN_SCENE));
        }
        AsyncOperation SceneLoadOperation = SceneManager.LoadSceneAsync(MAIN_SCENE, LoadSceneMode.Additive);
        while (!SceneLoadOperation.isDone)
        {
            yield return null;
        }
        LoadScene();
        // Tambah FadeOverlay
    }
    public void LoadScene()
    {
        MainThreadDispatcher.StartCoroutine(LoadOverWorldScene());
    }
    public IEnumerator LoadOverWorldScene()
    {
        if (SceneManager.GetSceneByName(Over_World_Scene).isLoaded)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(Over_World_Scene));
        }
        // Tambah FadeOverlay
        if (!SceneManager.GetSceneByName(Over_World_Scene).isLoaded)
        {
            AsyncOperation SceneLoadOperation = SceneManager.LoadSceneAsync(Over_World_Scene, LoadSceneMode.Additive);
            while (!SceneLoadOperation.isDone)
            {
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Over_World_Scene));
        // Tambah FadeOverlay
        }
    }
}
