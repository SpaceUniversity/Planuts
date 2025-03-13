using UnityEngine;

namespace Default.Scripts.BehaviourTree.Runtime.Actions {
    [System.Serializable]
    public class Breakpoint : ActionNode
    {
        protected override void OnStart() {
            Debug.Log("Trigging Breakpoint");
            Debug.Break();
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            return State.Success;
        }
    }
}
