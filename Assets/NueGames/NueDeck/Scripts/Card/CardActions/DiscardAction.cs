using NueGames.NueDeck.Scripts.Collection;
using NueGames.NueDeck.Scripts.Enums;
using NueGames.NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueGames.NueDeck.Scripts.Card.CardActions
{
    public class DiscardAction : CardActionBase
    {
        public override CardActionType ActionType => CardActionType.Discard;
        public override void DoAction(CardActionParameters actionParameters)
        {
            //Discards the card to the right of the played card
            if (CollectionManager != null)
                for(int i = 0; i < Mathf.RoundToInt(actionParameters.Value); i++){
                    CollectionManager.DiscardMostRightCard();
                }
                
            else
                Debug.LogError("There is no CollectionManager");

            if (FxManager != null)
                FxManager.PlayFx(actionParameters.SelfCharacter.transform, FxType.Buff);

            if (AudioManager != null)
                AudioManager.PlayOneShot(actionParameters.CardData.AudioType);
                
        }
    }
}