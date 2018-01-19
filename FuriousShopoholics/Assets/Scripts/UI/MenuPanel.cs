using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuPanel : MonoBehaviour
{ 
    private Canvas _canvas;

    [Inject]
    public void Construct(Canvas canvas)
    {
        _canvas = canvas;
        return;
    }

    public void Start()
    {
        transform.SetParent(_canvas.transform, false);
        return;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
        return;
    }
}
