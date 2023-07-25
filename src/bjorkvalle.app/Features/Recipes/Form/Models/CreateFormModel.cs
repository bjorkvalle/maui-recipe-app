using System.ComponentModel.DataAnnotations;

namespace bjorkvalle.app.Features.Recipes
{
    public record CreateFormModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Html")]
        public string Html { get; init; }

        public string Delta { get; init; }
    }
}
