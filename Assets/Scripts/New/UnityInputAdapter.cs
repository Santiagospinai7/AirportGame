using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComputacionGrafica.Airport
{
    public class UnityInputAdapter : IInput
    {
        public Vector3 GetDirection()
        {
            var horizontalDir = Input.GetAxis("Horizontal");
            var verticalDir = Input.GetAxis("Vertical");
            //AudioPlayer._instance.PlaySFX("walk");
            return new Vector3(horizontalDir, 0, verticalDir);
        }

        public bool RunActionPressed()
        {
            //AudioPlayer._instance.PlaySFX("run");
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }

        public bool JumpActionPressed()
        {
            return Input.GetKey(KeyCode.Space);
        }

        public bool Attack1ActionPressed()
        {
            return Input.GetKeyDown(KeyCode.Q);
        }

        public bool Attack2ActionPressed()
        {
            return Input.GetKeyDown(KeyCode.W);
        }

        public bool Attack3ActionPressed()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        public bool Attack4ActionPressed()
        {
            return Input.GetKey(KeyCode.R);
        }

        public bool RightClickActionPressed()
        {
            return Input.GetMouseButtonDown(1);
        }
    }
}