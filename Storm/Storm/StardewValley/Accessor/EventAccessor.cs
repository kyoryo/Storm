using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile;

namespace Storm.StardewValley.Accessor
{
    public interface EventAccessor
    {
        String _GetEventCommands();
        void _SetEventCommands(String val);

        int _GetCurrentCommand();
        void _SetCurrentCommand(int val);

        int _GetOldPixelZoom();
        void _SetOldPixelZoom(int val);

        int _GetReadyConfirmationTimer();
        void _SetReadyConfirmationTimer(int val);

        IList _GetActors();
        void _SetActors(IList val);

        IList _GetProps();
        void _SetProps(IList val);

        IList _GetFestivalProps();
        void _SetFestivalProps(IList val);

        String _GetMessageToScreen();
        void _SetMessageToScreen(String val);

        String _GetPlayerControlSequenceID();
        void _SetPlayerControlSequenceID(String val);

        bool _GetShowActiveObject();
        void _SetShowActiveObject(bool val);

        bool _GetContinueAfterMove();
        void _SetContinueAfterMove(bool val);

        bool _GetSpecialEventVariable1();
        void _SetSpecialEventVariable1(bool val);

        bool _GetForked();
        void _SetForked(bool val);

        bool _GetWasBloomDay();
        void _SetWasBloomDay(bool val);

        bool _GetWasBloomVisible();
        void _SetWasBloomVisible(bool val);

        bool _GetPlayerControlSequence();
        void _SetPlayerControlSequence(bool val);

        bool _GetEventSwitched();
        void _SetEventSwitched(bool val);

        bool _GetIsFestival();
        void _SetIsFestival(bool val);

        bool _GetSentReadyConfirmation();
        void _SetSentReadyConfirmation(bool val);

        bool _GetAllPlayersReady();
        void _SetAllPlayersReady(bool val);

        bool _GetPlayerWasMounted();
        void _SetPlayerWasMounted(bool val);

        IDictionary _GetActorPositionsAfterMove();
        void _SetActorPositionsAfterMove(IDictionary val);

        float _GetTimeAccumulator();
        void _SetTimeAccumulator(float val);

        float _GetViewportXAccumulator();
        void _SetViewportXAccumulator(float val);

        float _GetViewportYAccumulator();
        void _SetViewportYAccumulator(float val);

        Vector3 _GetViewportTarget();
        void _SetViewportTarget(Vector3 val);

        Color _GetPreviousAmbientLight();
        void _SetPreviousAmbientLight(Color val);

        IList _GetNpcsWithUniquePortraits();
        void _SetNpcsWithUniquePortraits(IList val);

        ContentManager _GetTemporaryContent();
        void _SetTemporaryContent(ContentManager val);

        GameLocationAccessor _GetTemporaryLocation();
        void _SetTemporaryLocation(GameLocationAccessor val);

        Point _GetPlayerControlTargetTile();
        void _SetPlayerControlTargetTile(Point val);

        Texture2D _GetFestivalTexture();
        void _SetFestivalTexture(Texture2D val);

        IList _GetNpcControllers();
        void _SetNpcControllers(IList val);

        NPCAccessor _GetSecretSantaRecipient();
        void _SetSecretSantaRecipient(NPCAccessor val);

        NPCAccessor _GetMySecretSanta();
        void _SetMySecretSanta(NPCAccessor val);

        bool _GetSkippable();
        void _SetSkippable(bool val);

        int _GetId();
        void _SetId(int val);

        IList _GetCharacterWalkLocations();
        void _SetCharacterWalkLocations(IList val);

        IDictionary _GetFestivalData();
        void _SetFestivalData(IDictionary val);

        int _GetOldShirt();
        void _SetOldShirt(int val);

        Color _GetOldPants();
        void _SetOldPants(Color val);

        bool _GetSkipped();
        void _SetSkipped(bool val);

        bool _GetWaitingForMenuClose();
        void _SetWaitingForMenuClose(bool val);

        int _GetOldTime();
        void _SetOldTime(int val);

        IList _GetUnderwaterSprites();
        void _SetUnderwaterSprites(IList val);

        IList _GetAboveMapSprites();
        void _SetAboveMapSprites(IList val);

        NPCAccessor _GetFestivalHost();
        void _SetFestivalHost(NPCAccessor val);

        String _GetHostMessage();
        void _SetHostMessage(String val);

        int _GetFestivalTimer();
        void _SetFestivalTimer(int val);

        ItemAccessor _GetTempItemStash();
        void _SetTempItemStash(ItemAccessor val);

        int _GetGrangeScore();
        void _SetGrangeScore(int val);

        FarmerAccessor _GetPlayerUsingGrangeDisplay();
        void _SetPlayerUsingGrangeDisplay(FarmerAccessor val);

        int _GetPreviousFacingDirection();
        void _SetPreviousFacingDirection(int val);

        IDictionary _GetFestivalShops();
        void _SetFestivalShops(IDictionary val);

        int _GetPreviousAnswerChoice();
        void _SetPreviousAnswerChoice(int val);

        bool _GetStartSecretSantaAfterDialogue();
        void _SetStartSecretSantaAfterDialogue(bool val);

        IList _GetGrangeDisplay();
        void _SetGrangeDisplay(IList val);

        bool _GetSpecialEventVariable2();
        void _SetSpecialEventVariable2(bool val);

        IList _GetLuauIngredients();
        void _SetLuauIngredients(IList val);
    }
}
