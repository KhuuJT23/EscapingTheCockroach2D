using UnityEngine;

using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void levelSwitching()
    {
        SceneManager.LoadScene("TestingCodesLevel2");
    }

}
