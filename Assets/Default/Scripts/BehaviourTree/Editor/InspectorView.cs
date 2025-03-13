using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Default.Scripts.BehaviourTree {

    [UxmlElement]
    public partial class InspectorView : VisualElement {

        public InspectorView() {

        }

        internal void UpdateSelection(SerializedBehaviourTree serializer, NodeView nodeView) {
            Clear();

            if (nodeView == null) {
                return;
            }

            var nodeProperty = serializer.FindNode(serializer.Nodes, nodeView.node);
            if (nodeProperty == null) {
                return;
            }

            // Auto-expand the property
            nodeProperty.isExpanded = true;

            // Property field
            PropertyField field = new PropertyField();
            field.label = nodeProperty.managedReferenceValue.GetType().ToString();
            field.BindProperty(nodeProperty);

            Add(field);
        }
    }
}