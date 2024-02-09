using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    // a reference to a KitchenObjectSO. This represents the data associated with this kitchen object.
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // a reference to an object that implements the IKitchenObjectParent interface.
    private IKitchenObjectParent kitchenObjectParent;

    // call the KitchenObjectSO associated with this kitchen object.
    public KitchenObjectSO GetKitchenObjectSO() 
    { 
        return kitchenObjectSO; 
    }

    // Sets the parent for this kitchen object
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        // Checks if there's already a parent assigned (kitchenObjectParent) and clears it if it exists.
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }

        // Assigns the new kitchenObjectParent provided as an argument.
        this.kitchenObjectParent = kitchenObjectParent;

        // Checks if the new parent already has a kitchen object; if it does, it logs an error.
        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter already has a KitchenObject !");
        }

        // Sets this kitchen object as a child object to the new parent using its SetKitchenObject method.
        kitchenObjectParent.SetKitchenObject(this);

        // Positions the kitchen object relative to its parent based on the GetKitchenObjectFollowTransform() method of the parent
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    // Call the parent object implementing the IKitchenObjectParent interface.
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject= null;
            return false;
        }
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);

        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();

        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }
}
