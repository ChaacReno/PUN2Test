using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneFromData(RoomData roomData)
    {
        SceneManager.LoadScene(roomData.SceneId);
    }
}
