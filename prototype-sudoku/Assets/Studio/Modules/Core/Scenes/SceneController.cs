using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Studio.Modules.Core.Scenes
{
    public class SceneController
    {
        #region Variables
        private const string MAIN_MENU_SCENE_NAME = "Sudoku - Start";
        private const string GAME_SCENE_NAME = "Sudoku - Game";
        #endregion

        #region Methods
        public IEnumerator ChangeScene(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            yield return LoadAsyncActiveScene(sceneName);
        }

        public IEnumerator LoadAsyncActiveScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(loadedScene);
        }

        public void LoadStartScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
        }

        public void LoadGameScene() 
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(GAME_SCENE_NAME);
        }
        #endregion
    }
}