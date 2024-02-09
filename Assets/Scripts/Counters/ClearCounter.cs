using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // there is no kitchen object here
            if (player.HasKitchenObject())
            {
                // player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }

            else
            {
                // player is not carrying anything
            }
        }

        else
        {
            // there is a kitchen object here
            if (player.HasKitchenObject())
            {
                // player is carrying something

                if (player.GetKitchenObject() is PlateKitchenObject)
                {
                    // Player is holding a plate
                    if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                        {
                            GetKitchenObject().DestroySelf();
                        }
                    }
                    else
                    {
                        // Player is not carrying Plate but something else
                        if (GetKitchenObject().TryGetPlate(out  plateKitchenObject))
                        {
                            // Counter is holding a Plate
                            if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                            {
                                player.GetKitchenObject().DestroySelf();
                            }
                        }
                    }
                }
            }
            else
            {
                // player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
