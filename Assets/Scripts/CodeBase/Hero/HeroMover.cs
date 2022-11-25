using Assets.CodeBase.Services.Input;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;
        private Vector3 _direction;
        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            _direction = Vector3.zero;
            /*
            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                _direction = _camera.transform.TransformDirection(_inputService.Axis);
                _direction.y = 0;
                _direction.Normalize();

                transform.forward = _direction;
            }
            */

            _direction += Physics.gravity;

            _characterController.Move(_direction * _speed * Time.deltaTime);
        }
    }
}