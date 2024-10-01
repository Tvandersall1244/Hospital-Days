using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{

    Transform GetTransform();
    void Interact(Transform position);
}
