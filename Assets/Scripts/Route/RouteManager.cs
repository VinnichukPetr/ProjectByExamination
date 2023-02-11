using UnityEngine;
using UnityEngine.SceneManagement;

namespace Route
{
    public class RouteManager:MonoBehaviour
    {
        public void ChangeScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Close()
        {
            Application.Quit();
        }
    }
}