using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using MEC;
using PlayerRoles;

namespace AliveReporter
{
    public class EventHandler
    {
        private static CoroutineHandle _coroutineTimer;
        
        private void InitCassie()
        {
            List<Player> players = Player.List.ToList();
            string cassieText = "";
            string translatedText = "";

            int DClass = 0;
            int scientists = 0;
            int guards = 0;
            int NTFs = 0;
            int CIs = 0;
            int SCPs = 0;

            Player savedPlayer = players[0];

            foreach (var player in players)
            {
                if (player.Role == RoleTypeId.ClassD && Plugin.Instance.Config.ReportDclass) DClass++;
                else if (player.Role == RoleTypeId.Scientist && Plugin.Instance.Config.ReportScientist) scientists++;
                else if (player.Role == RoleTypeId.FacilityGuard && Plugin.Instance.Config.ReportGuard) guards++;
                else if (player.IsNTF && Plugin.Instance.Config.ReportNtf) NTFs++;
                else if (player.IsCHI && Plugin.Instance.Config.ReportCi) CIs++;
                else if (player.IsScp && Plugin.Instance.Config.ReportScp) SCPs++;
            }

            if (DClass > 0)
            {
                cassieText += (DClass + " D Class");
                translatedText += (DClass + " D-Class ");
            }
            if (scientists > 0)
            {
                cassieText += (scientists + " scientists");
                translatedText += (scientists + " scientists ");
            }
            if (guards > 0) {
                cassieText += (guards + " guards");
                translatedText += (guards + " guards ");
            }
            if (NTFs > 0) {
                cassieText += (NTFs + " N T F operators");
                translatedText += (NTFs + " NTF operators ");
            }
            if (CIs > 0) {
                cassieText += (CIs + " Chaos operators");
                translatedText += (CIs + " Chaos operators ");
            }
            if (SCPs > 0) {
                cassieText += (SCPs + " SCPs");
                translatedText += (SCPs + " SCPs ");
            }

            var originText = Plugin.Instance.Config.CassieText;
            var speakText = originText.Replace("$Info$", cassieText);
            var translated = originText.Replace("$Info$", translatedText);
            
            Cassie.MessageTranslated(speakText, translated);
            
        }

        private IEnumerator<float> CoroutineTimer()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(Plugin.Instance.Config.ReportTimer);
                InitCassie();
            }
            
        }
        
        public void OnRoundStarted()
        {
            if (Plugin.Instance.Config.ReportOnStart) InitCassie();
            _coroutineTimer = Timing.RunCoroutine(CoroutineTimer());
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            if (_coroutineTimer.IsRunning) Timing.KillCoroutines(_coroutineTimer);
        }
    }
}