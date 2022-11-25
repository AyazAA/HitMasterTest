using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public abstract class InputSevice : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string Button = "Fire";

        public Vector2 TapPosition 
            => UnityEngine.Input.mousePosition;
        
        public abstract bool IsTapToScreen();
    }
}