using UnityEngine;

namespace Interfaces
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
