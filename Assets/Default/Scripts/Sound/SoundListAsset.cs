﻿using System.Collections.Generic;
using System.Linq;
using Default.Scripts.Editor.Extension;
using UnityEditor;
using UnityEngine;

namespace Default.Scripts.Sound
{
#if UNITY_EDITOR
    [CustomEditor(typeof(SoundListAsset))]
    public class SoundListAssetInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var sl = (SoundListAsset)target;
            if (GUILayout.Button("Load All Sound"))
            {
                EditorUtility.SetDirty(target);
                var clips = sl.floder.LoadAllObjectsInFolder<AudioClip>();
                var tmp = new List<Sound>();
                foreach (var clip in clips)
                {
                    tmp.Add(new Sound(clip));
                }
                sl.sounds = tmp.ToArray();
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }
#endif
    [CreateAssetMenu(fileName = "Sound List Asset",menuName = "Sound/Sound LIst Asset")]
    public class SoundListAsset : ScriptableObject
    {
        public Sound[] sounds;
#if UNITY_EDITOR
        public DefaultAsset floder;
#endif
        public Sound GetSoundByName(string name)
        {
            var soundsQuery = from sound in sounds
                where sound.name == name
                select sound;
            foreach (var sound in soundsQuery)
            {
                return sound;
            }

            return null;
        }
    }
}