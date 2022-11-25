using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public class MobileInputService : InputSevice
    {
        public override bool IsTapToScreen()
        {
            return UnityEngine.Input.touchCount > 0;
        }
    }
}