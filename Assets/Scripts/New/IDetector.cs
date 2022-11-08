using UnityEngine;
using System.Collections.Generic;

public interface IDetector
{
    bool IsDetected();
    List<GameObject> AllObjectsDetected();
    GameObject ObjectDetected();
}
