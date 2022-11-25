using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 TapPosition
        {
            get;
        }
        
        bool IsTapToScreen();
    }
}