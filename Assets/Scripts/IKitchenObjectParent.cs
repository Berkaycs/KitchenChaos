using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Defines a set of methods that any class implementing this interface must include
public interface IKitchenObjectParent
{
    // This method is expected to return a Transform that serves as a reference point or location where a kitchen object should be placed or follow.
    public Transform GetKitchenObjectFollowTransform();

    // Sets a KitchenObject instance within the implementing class.
    // This method likely takes a KitchenObject as an argument and handles the logic for assigning it to the implementing class.
    public void SetKitchenObject(KitchenObject kitchenObject);

    // Call the KitchenObject that has been set within the implementing class using the SetKitchenObject method.
    public KitchenObject GetKitchenObject();

    // removes the KitchenObject from the implementing class. This method likely performs any necessary cleanup related to the kitchen object.
    public void ClearKitchenObject();

    // Checks if the implementing class currently has a KitchenObject set.
    public bool HasKitchenObject();
}
