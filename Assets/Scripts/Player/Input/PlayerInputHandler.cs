using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public void OnMoveInput(InputAction.CallbackContext callbackContext)
        {
            print("lol");
        }

        public void OnJumpInput(InputAction.CallbackContext callbackContext)
        {
            
        }
    }
}