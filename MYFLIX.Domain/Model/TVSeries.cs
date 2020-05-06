using System;
using System.ComponentModel.DataAnnotations;

namespace MYFLIX.Data.Model
{
    public class TVSeries : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Director { get; set; }

        public string Star { get; set; }

        public DateTime WatchedDateTime { get; set; }

        public int CurrentSeason { get; set; }

        public int CurrentEpisode { get; set; }

        public bool IsFinish { get; set; }

        public int MyScore { get; set; }

        public string Image { get; set; } 

        [Display(Name = "IMDB Score")]
        public int ImdbScore { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
