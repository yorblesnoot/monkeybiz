using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class RagComponentAdder : MonoBehaviour
{
    
}

[CustomEditor(typeof(RagComponentAdder))]
public class RagAddedEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Add Components"))
        {
            RagComponentAdder adder = target as RagComponentAdder;
            Traverse(adder.transform, AddRagComponents);
        }
        DrawDefaultInspector();
    }

    void AddRagComponents(Transform transform)
    {
        transform.gameObject.AddComponent<CapsuleCollider>();
        transform.gameObject.AddComponent<Rigidbody>();
        transform.gameObject.AddComponent<CharacterJoint>();
    }

    void Traverse(Transform target, Action<Transform> action)
    {
        action(target);
        foreach (Transform child in target)
        {
            Traverse(child, action);
        }
    }
}
