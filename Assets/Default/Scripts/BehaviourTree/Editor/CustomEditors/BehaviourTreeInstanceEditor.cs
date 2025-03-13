using Default.Scripts.BehaviourTree.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Default.Scripts.BehaviourTree.CustomEditors {
    [CustomEditor(typeof(BehaviourTreeInstance))]
    public class BehaviourTreeInstanceEditor : UnityEditor.Editor {

        public override VisualElement CreateInspectorGUI() {

            VisualElement container = new VisualElement();

            PropertyField treeField = new PropertyField();
            treeField.bindingPath = nameof(BehaviourTreeInstance.behaviourTree);

            PropertyField validateField = new PropertyField();
            validateField.bindingPath = nameof(BehaviourTreeInstance.validate);

            PropertyField tickMode = new PropertyField();
            tickMode.bindingPath = nameof(BehaviourTreeInstance.tickMode);

            PropertyField startMode = new PropertyField();
            startMode.bindingPath = nameof(BehaviourTreeInstance.startMode);

            PropertyField publicKeys = new PropertyField();
            publicKeys.bindingPath = nameof(BehaviourTreeInstance.blackboardOverrides);

            container.Add(treeField);
            container.Add(tickMode);
            container.Add(startMode);
            container.Add(validateField);
            container.Add(publicKeys);

            return container;
        }
    }
}
