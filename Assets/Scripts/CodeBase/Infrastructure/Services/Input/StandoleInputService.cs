using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public class StandoleInputService : InputSevice
    {
        public override bool IsTapToScreen()
        {
            return UnityEngine.Input.GetMouseButtonDown(0);
        }
    }
}