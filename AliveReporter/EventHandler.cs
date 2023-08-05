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
            //string cassieText = ;

            int DClass = 0;
            int scientists = 0;
            int guards = 0;
            int NTFs = 0;
            int CIs = 0;
            int SCPs = 0;

            foreach (var player in players)
            {
                if (player.Role == RoleTypeId.ClassD && Plugin.Instance.Config.ReportDclass) DClass++;
                if (player.Role == RoleTypeId.Scientist && Plugin.Instance.Config.ReportScientist) scientists++;
                if (player.Role == RoleTypeId.FacilityGuard && Plugin.Instance.Config.ReportGuard) guards++;
                if (player.IsNTF && Plugin.Instance.Config.ReportNtf) NTFs++;
                if (player.IsCHI && Plugin.Instance.Config.ReportCi) CIs++;
                if (player.IsScp && Plugin.Instance.Config.ReportScp) SCPs++;
            }
            
            //if (DClass > 0) cassieText += 
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