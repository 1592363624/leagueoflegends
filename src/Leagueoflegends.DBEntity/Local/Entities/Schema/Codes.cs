﻿using System.ComponentModel.DataAnnotations;

namespace Leagueoflegends.DBEntity.Local.Entities.Schema
{
    public class Codes
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Explain { get; set; }
    }
}