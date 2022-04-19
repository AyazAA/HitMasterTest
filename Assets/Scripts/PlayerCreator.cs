using UnityEngine;

public class PlayerCreator: MonoBehaviour
{
    [SerializeField] private MoveToPoints _playerPrefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform[] _points;
    [SerializeField] private EnemyGroup[] _enemyGroups;
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private CameraController _cameraController;


    private void Start()
    {
        var player = Instantiate(_playerPrefab, _startPoint.position, Quaternion.identity);
        player.Construct(_points, _enemyGroups);
        player.gameObject.GetComponentInChildren<Weapon>().Construct(_bulletPool);
        _progressBar.Construct(player);
        _cameraController.Construct(player.transform);
    }
}
