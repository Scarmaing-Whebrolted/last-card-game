namespace LastCard
{
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;

    public class CardsPile : MonoBehaviour
    {
        [SerializeField]
        private Transform cardsHolder;

        private List<Card> cards = new List<Card>();
        private CardsDeck deck;

        public bool IsIncrementing = false;
        public bool HasAliasThree { get; set; } = false;
        public bool SkipTurn { get; set; } = false;
        public bool Reversed { get; set; } = false;

        public void Init(CardsDeck cardsDeck)
        {
            deck = cardsDeck;
        }
        
        public Card PeekCard()
        {
            if (cards.Count - 1 < 0)
            {
                return null;
            }

            return cards.Last();
        }

        public void PushCard(Card card)
        {
            Debug.Log(card.name);

            if (HasAliasThree)
            {
                HasAliasThree = false;
            }

            switch (card.nominal)
            {
                case Nominal.Four:
                    IsIncrementing = true;
                    break;
                case Nominal.Two:
                    SkipTurn = true;
                    break;
                case Nominal.Three:
                    HasAliasThree = true;
                    break;
                case Nominal.Ace:
                    Reversed = !Reversed;
                    break;
                case Nominal.Ten:
                    IsIncrementing = false;
                    break;
                default:
                    break;
            }

            cards.Add(card);
            card.transform.SetParent(cardsHolder.transform, false);
        }
    }
}
