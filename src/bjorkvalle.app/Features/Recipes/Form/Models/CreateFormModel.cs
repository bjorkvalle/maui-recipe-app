﻿using System.ComponentModel.DataAnnotations;

namespace bjorkvalle.app.Features.Recipes
{
    public record CreateFormModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Cover")]
        public string CoverImg { get; set; }

        [Display(Name = "Source")]
        public string Source { get; set; }

        [Display(Name = "Html")]
        public string Html { get; set; }

        public string Delta { get; set; }
    }
}
