using UnityEngine;

public interface IChasable
{
    Transform ChasingTransform { get; }
    void TryCatch(ICatchable catchable);
}
