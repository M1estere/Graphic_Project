using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }

        public int NormalizedInputX { get; private set; }
        public int NormalizedInputY { get; private set; }
        
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }

        public bool[] AttackInputs { get; private set; }
        
        [SerializeField] private float _inputHoldTime = .2f;

        private float _jumpStartTime;

        private void Start()
        {
            int count = Enum.GetValues(typeof(CombatInputs)).Length;
            AttackInputs = new bool[count];
        }

        private void Update()
        {
            CheckJumpInputHoldTime();
        }

        public void OnPrimaryAttackInput(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
            {
                AttackInputs[(int)CombatInputs.primary] = true;
            }

            if (callbackContext.canceled)
            {
                AttackInputs[(int)CombatInputs.primary] = false;
            }
        }

        public void OnSecondaryAttackInput(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
            {
                AttackInputs[(int)CombatInputs.secondary] = true;
            }

            if (callbackContext.canceled)
            {
                AttackInputs[(int)CombatInputs.secondary] = false;
            }
        }
        
        public void OnMoveInput(InputAction.CallbackContext callbackContext)
        {
            RawMovementInput = callbackContext.ReadValue<Vector2>();

            NormalizedInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormalizedInputY = Mathf.RoundToInt(RawMovementInput.y);
        }

        public void OnJumpInput(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
            {
                JumpInput = true;
                JumpInputStop = false;
                _jumpStartTime = Time.time;
            }

            if (callbackContext.canceled)
            {
                JumpInputStop = true;
            }
        }

        public void UseJumpInput() => JumpInput = false;

        private void CheckJumpInputHoldTime()
        {
            if (Time.time >= _jumpStartTime + _inputHoldTime)
            {
                JumpInput = false;
            }
        }
    }

    public enum CombatInputs
    {
        primary,
        secondary,
    }
}