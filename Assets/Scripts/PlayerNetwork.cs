using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour {
  NetworkVariable<int> randNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

  public override void OnNetworkSpawn() {
    randNumber.OnValueChanged += (int prevVal, int newVal) => {
      Debug.Log(OwnerClientId + " - " + randNumber.Value);
    }
  }
  
  void Update() {
    if(!IsOwner) return;

    if(Input.GetKeyDown(KeyCode.T))
      randNumber.Value = Random.Range(0,100);

    Vector3 moveDir = new Vector3(0,0,0);

    if(Input.GetKey(KeyCode.W)) moveDir.z = 1f;
    if(Input.GetKey(KeyCode.S)) moveDir.z = -1f;
    if(Input.GetKey(KeyCode.A)) moveDir.x = -1f;
    if(Input.GetKey(KeyCode.D)) moveDir.x = 1f;

    float moveSpeed = 3f;
    transform.position += moveDir * moveSpeed * Time.deltaTime;
  }
}
