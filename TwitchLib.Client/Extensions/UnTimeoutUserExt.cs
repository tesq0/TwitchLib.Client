using System;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Extensions
{
    /// <summary>Extension implementing untimeout functionality in TwitchClient</summary>
    public static class UnTimeoutUserExt
    {
        #region UnTimeoutUser
        /// <summary>
        /// UnTimesout a user in chat using a JoinedChannel object.
        /// </summary>
        /// <param name="channel">Channel object to send the untimeout command to.</param>
        /// <param name="viewer">Viewer name to untimeout</param>
        /// <param name="dryRun">Indicates a dryrun (will not send if true).</param>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void UnTimeoutUser(this ITwitchClient client, JoinedChannel channel, string viewer, bool dryRun = false)
        {
            client.SendMessage(channel, $".untimeout {viewer}", dryRun);
        }

        /// <summary>
        /// UnTimesout a user in chat using a string for the channel.
        /// </summary>
        /// <param name="channel">Channel in string form to send the untimeout command to</param>
        /// <param name="viewer">Viewer name to untimeout.</param>
        /// <param name="dryRun">Indicates a dryrun (will not send if true).</param>
        /// <param name="client">Client reference used to identify extension.</param>
        public static void UnTimeoutUser(this ITwitchClient client, string channel, string viewer, bool dryRun = false)
        {
            var joinedChannel = client.GetJoinedChannel(channel);
            if (joinedChannel != null)
                UnTimeoutUser(client, joinedChannel, viewer, dryRun);
        }
        #endregion
    }
}
