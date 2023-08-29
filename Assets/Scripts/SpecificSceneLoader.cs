using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecificSceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneId = 13;

    public void LoadSpecificScene()
    {
        SceneManager.LoadScene(sceneId);
    }
}
