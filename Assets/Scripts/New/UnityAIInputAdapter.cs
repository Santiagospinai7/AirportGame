using UnityEngine;

namespace ComputacionGrafica.Airport
{
    public class UnityAIInputAdapter : IInput
    {
        private LayerMask _layerGround = 1 << 6;

        public Vector3 GetDirection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 direction = Vector2.zero;

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerGround)) // ~
            {
                direction = hit.point;
            }
            //AudioPlayer._instance.PlaySFX("walk");
            return direction;
        }

        public bool RunActionPressed()
        {
            //AudioPlayer._instance.PlaySFX("run");
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }

        public bool JumpActionPressed()
        {
            //AudioPlayer._instance.PlaySFX("jump");
            return Input.GetKeyDown(KeyCode.Space);
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
            //AudioPlayer._instance.PlaySFX("shuriken");
            return Input.GetKey(KeyCode.R);
        }

        public bool RightClickActionPressed()
        {
            return Input.GetMouseButtonDown(1);
        }
    }
}
