using System.Collections;
using UnityEngine;

namespace ComputacionGrafica.Airport
{
    public interface IInput
    {
        Vector3 GetDirection();
        bool RunActionPressed();
        bool JumpActionPressed();
        bool Attack1ActionPressed();
        bool Attack2ActionPressed();
        bool Attack3ActionPressed();
        bool Attack4ActionPressed();
        bool RightClickActionPressed();
    }
}
