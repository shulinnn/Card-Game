using Assets.Scripts.Core;
using Mirror;

namespace Assets.Scripts.Multiplayer
{
    public class HandComponent : NetworkBehaviour
    {

        public readonly SyncList<Card> inventory = new SyncList<Card>();


        // this will add the delegates on both server and client.
        // Use OnStartClient instead if you just want the client to act upon updates
        void Start()
        {
            inventory.Callback += OnInventoryUpdated;
        }

        public override void OnStartServer()
        {
            inventory.Add(CardDatabase.Instance.AllCardsInGame[0]);
            inventory.Add(CardDatabase.Instance.AllCardsInGame[1]);
            inventory.Add(CardDatabase.Instance.AllCardsInGame[2]);
            inventory.Add(CardDatabase.Instance.AllCardsInGame[3]);
        }


        void OnInventoryUpdated(SyncList<Card>.Operation op, int index, Card oldItem, Card newItem)
        {
            switch (op)
            {
                case SyncList<Card>.Operation.OP_ADD:
                    // index is where it got added in the list
                    // item is the new item
                    break;
                case SyncList<Card>.Operation.OP_CLEAR:
                    // list got cleared
                    break;
                case SyncList<Card>.Operation.OP_INSERT:
                    // index is where it got added in the list
                    // item is the new item
                    break;
                case SyncList<Card>.Operation.OP_REMOVEAT:
                    // index is where it got removed in the list
                    // item is the item that was removed
                    break;
                case SyncList<Card>.Operation.OP_SET:
                    // index is the index of the item that was updated
                    // item is the previous item
                    break;
            }
        }

    }
}
