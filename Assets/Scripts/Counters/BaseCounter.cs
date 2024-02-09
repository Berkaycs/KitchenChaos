using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    // when use the protected keyword just this class and class that does inheritance from this class can use the func
    // when use the abstract keyword it forces all the classes to implement their own implementation
    // virtual anahtar kelimesi, bir �st s�n�fta (base class) tan�mlanan bir metodun alt s�n�flarda (derived class)
    // yeniden tan�mlanabilece�ini belirtir. Bu, alt s�n�flar�n ayn� ad ve imzaya sahip metodlar� kendi gereksinimlerine g�re de�i�tirmelerini sa�lar.

    public static event EventHandler OnAnyObjectPlaceHere;

    public static void ResetStaticData()
    {
        OnAnyObjectPlaceHere = null;
    }

    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter.Interact();");
    }
    public virtual void InteractAlternate(Player player)
    {
        Debug.LogError("BaseCounter.InteractAlternate();");
    }

    // Implements methods required by the IKitchenObjectParent interface, such as setting/getting the kitchen object parent,
    // handling kitchen object assignment, clearing the kitchen object, and checking if the counter has a kitchen object
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;

        if (kitchenObject != null )
        {
            OnAnyObjectPlaceHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
