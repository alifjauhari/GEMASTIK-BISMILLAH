using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerWithUnityEvent : MonoBehaviour {

    [SerializeField] string targetTag;

    [SerializeField, Space(10)] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;


    [SerializeField] bool isSendMessageOnEnter;
    [SerializeField] string message;

    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag(targetTag)) return;

        onTriggerEnter.Invoke();
        if (!isSendMessageOnEnter) return;

        other.SendMessage(message);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.gameObject.CompareTag(targetTag)) return;


        onTriggerExit.Invoke();
    }
}
