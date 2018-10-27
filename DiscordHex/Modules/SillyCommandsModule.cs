﻿using Discord;
using Discord.Commands;
using DiscordHex.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordHex.Modules
{
    public class SillyCommandsModule : ModuleBase<SocketCommandContext>
    {
        private List<string> words;

        public SillyCommandsModule()
        {
            words = new List<string>
            {
                "Booty booty rump rump, {0} got a pretty butt bump",
                "{0} likes butts and cannot lie.",
                "Did you try buffing?",
                "Butts.. That's all.",
                "Butty butty bum bum",
                "You pervert!"
            };
        }

        [Command("butt")]
        [Summary("Bum bum")]
        public async Task Butt(params string[] message)
        {
            var emb = new EmbedBuilder();
            var text = words.ElementAt(BotSettings.Instance.RandomNumber.Next(0, words.Count));

            text = string.Format(text, Context.Message.Author.Username);

            emb.Description = text;

            await ReplyAsync("", false, emb.Build());
        }

        [Command("hiss")]
        public async Task Hissss(params string[] message)
        {
            var emb = new EmbedBuilder();

            var text = Context.Message.MentionedUsers.Count > 0
                ? $"{Context.Message.Author.Username} hisses at {Context.Message.MentionedUsers.First().Username}!"
                : $"{Context.Message.Author.Username} hisses!";

            if (Context.Message.MentionedUsers.Count > 0)
                emb.ImageUrl = "https://media1.giphy.com/media/3oz8xBeYloJBY1TxN6/giphy.gif";
            else
                emb.ImageUrl = "https://media0.giphy.com/media/cz5pbZ7Ia5TNe/giphy.gif";

            emb.Description = text;

            await ReplyAsync("", false, emb.Build());
        }

        [Command("chop")]
        [Alias("chopchop")]
        [Summary("Chop!")]
        public async Task Chop(params string[] message)
        {
            var embedded = new EmbedBuilder();
            embedded.ImageUrl = "https://cdn.discordapp.com/attachments/461009638922649610/482247931831910411/aa7eb8e.gif";

            if (Context.Message.MentionedUsers.Count > 0)
            {
                embedded.Description = $"Chop! Chopchop, {Context.Message.MentionedUsers.First().Username}!";
            }
            else
            {
                embedded.Description = "Chop! Chopchop!";
            }

            await ReplyAsync("", false, embedded.Build());
        }
    }
}
