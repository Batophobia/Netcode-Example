using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour {
  [SerializeField] Button server;
  [SerializeField] Button host;
  [SerializeField] Button client;

  void Awake() {
    server.onClick.AddListener(() => { NetworkManager.Singleton.StartServer(); });
    host.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
    client.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });
  }
}