﻿
namespace DiscordHex.Domain
{
    public class SpellEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public SpellType Type { get; set; }
    }
}