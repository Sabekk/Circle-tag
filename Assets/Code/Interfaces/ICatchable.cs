using UnityEngine;

public interface ICatchable
{
    bool IsCatched { get; }
    void OnChatched();
}
