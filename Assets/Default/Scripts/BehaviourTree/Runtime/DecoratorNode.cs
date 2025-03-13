using UnityEngine;

namespace Default.Scripts.BehaviourTree.Runtime {
    public abstract class DecoratorNode : Node {

        [SerializeReference]
        [HideInInspector] 
        public Node child;
    }
}
