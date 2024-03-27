using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerCollisionsHandler.GameOver += LoadGameOverScene;
    }
    
    private void OnDisable()
    {
        PlayerCollisionsHandler.GameOver -= LoadGameOverScene;
    }
    
    private void LoadGameOverScene()
    {
        StartCoroutine(LoadGameOverWithDelay());
    }

    private IEnumerator LoadGameOverWithDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(GlobalConstants.GAMEOVER_SCENE);
    }
}