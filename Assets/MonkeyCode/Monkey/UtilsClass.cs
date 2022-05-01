using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CodeMonkey.Utils
{
    public class UtilsClass : MonoBehaviour
    {
        private static readonly Vector3 Vector3zero = Vector3.zero;
        private static readonly Vector3 Vector3one = Vector3.one;
        private static readonly Vector3 Vector3yDown = new Vector3(0, -1);

        public const int sortingOrderDefault = 5000;


        // Get Sorting order to set SpriteRenderer sortingOrder, higher position = lower sortingOrder
        public static int GetSortingOrder(Vector3 position, int offset, int baseSortingOrder = sortingOrderDefault)
        {
            return (int)(baseSortingOrder - position.y) + offset;
        }


        // Get Main Canvas Transform
        private static Transform cachedCanvasTransform;

        public static Transform GetCanvasTransform()
        {
            if (cachedCanvasTransform == null)
            {
                Canvas canvas = MonoBehaviour.FindObjectOfType<Canvas>();
                if (canvas != null)
                {
                    cachedCanvasTransform = canvas.transform;
                }
            }
            return cachedCanvasTransform;
        }


        // Get Default Unity Font, used in text objects if no font given
        public static Font GetDefaultFont()
        {
            return Resources.GetBuiltinResource<Font>("Arial.ttf");
        }


        // Create a Sprite in the World, no parent
        public static GameObject CreateWorldSprite(string name, Sprite sprite, Vector3 position, Vector3 localScale, int sortingOrder, Color color)
        {
            return CreateWorldSprite(null, name, sprite, position, localScale, sortingOrder, color);
        }


        // Create a Sprite in the World
        public static GameObject CreateWorldSprite(Transform parent, string name, Sprite sprite, Vector3 localPosition, Vector3 localScale, int sortingOrder, Color color)
        {
            GameObject gameObject = new GameObject(name, typeof(SpriteRenderer));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            transform.localScale = localScale;
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = sortingOrder;
            spriteRenderer.color = color;
            return gameObject;
        }


        // Get Mouse Position in World with Z = 0f
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }
        public static Vector3 GetMouseWorldPositionWithZ()
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }


        // Generate random normalized direction
        public static Vector3 GetRandomDir()
        {
            return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        }


        public static Vector3 GetVectorFromAngle(int angle)
        {
            // angle = 0 -> 360
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        public static Vector3 GetVectorFromAngle(float angle)
        {
            // angle = 0 -> 360
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }


        public static Vector3 GetVectorFromAngleInt(int angle)
        {
            // angle = 0 -> 360
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }


        public static float GetAngleFromVectorFloat(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }

        public static int GetAngleFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            int angle = Mathf.RoundToInt(n);

            return angle;
        }

        public static int GetAngleFromVector180(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            int angle = Mathf.RoundToInt(n);

            return angle;
        }

        public static Vector3 ApplyRotationToVector(Vector3 vec, Vector3 vecRotation)
        {
            return ApplyRotationToVector(vec, GetAngleFromVectorFloat(vecRotation));
        }

        public static Vector3 ApplyRotationToVector(Vector3 vec, float angle)
        {
            return Quaternion.Euler(0, 0, angle) * vec;
        }

    }
}
