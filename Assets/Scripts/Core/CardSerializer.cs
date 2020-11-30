
using Assets.Scripts.Multiplayer;
using Mirror;

namespace Assets.Scripts.Core
{
    public static class CardSerializer
    {
        public static void WriteCard(this NetworkWriter writer, Card card)
        {
            writer.WriteString(card.name);
        }
        public static Card ReadCard(this NetworkReader reader)
        {
            return CardDatabase.Instance.GetCardByName(reader.ReadString());
        }
    }
}
