using System.Collections.Generic;
using UnityEngine;

namespace Default.Scripts.BehaviourTree.Runtime {

    [System.Serializable]
    public abstract class CompositeNode : Node {

        [HideInInspector] 
        [SerializeReference]
        public List<Node> children = new List<Node>();
    }
}