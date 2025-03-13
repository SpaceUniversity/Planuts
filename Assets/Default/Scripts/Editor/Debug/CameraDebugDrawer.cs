using UnityEngine;

namespace Default.Scripts.Editor.Debug
{
    [ExecuteAlways]
    public class CameraDebugDrawer : MonoBehaviour
    {
        private Camera _camera;
        public Color debugColor = Color.green;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }
        private void OnDrawGizmos()
        {
            if (_camera == null)
                return;

            Vector3[] nearCorners = new Vector3[4];
            Vector3[] farCorners = new Vector3[4];

            _camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), _camera.nearClipPlane, Camera.MonoOrStereoscopicEye.Mono, nearCorners);
            _camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), _camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, farCorners);

            Transform camTransform = _camera.transform;

            for (int i = 0; i < 4; i++)
            {
                nearCorners[i] = camTransform.TransformPoint(nearCorners[i]);
                farCorners[i] = camTransform.TransformPoint(farCorners[i]);
            }

            // Debug.DrawLine을 사용하여 시각화
            DrawFrustumLines(nearCorners, farCorners, debugColor);
        }

        private void DrawFrustumLines(Vector3[] nearCorners, Vector3[] farCorners, Color color)
        {
            for (int i = 0; i < 4; i++)
            {
                int next = (i + 1) % 4;

                UnityEngine.Debug.DrawLine(nearCorners[i], nearCorners[next], color);

                UnityEngine.Debug.DrawLine(farCorners[i], farCorners[next], color);

                UnityEngine.Debug.DrawLine(nearCorners[i], farCorners[i], color);
            }
        }
    }
}
