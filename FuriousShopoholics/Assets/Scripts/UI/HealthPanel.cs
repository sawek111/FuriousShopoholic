using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] private Text health = null;

    private Player _player = null;
    private Canvas _canvas = null;

    [Inject]
    public void Construct(Player player, Canvas canvas)
    {
        _player = player;
        _canvas = canvas;

        return;
    }

    void Start()
    {
        transform.SetParent(_canvas.transform, false);
        return;
    }

    void Update()
    {
        if(_player != null)
        {
            health.text = "HP: " + _player.Health;
        }

        return;
    }
}
