using System.ComponentModel.DataAnnotations;

namespace bjorkvalle.app.Features.Config
{
    public record CreateModel
    {
        [Display(Name = "Name")]
        public string DbName { get; set; } = "fuudDb";//.sqlite3";
        
        [Display(Name = "Folder")]
        public string FolderPath { get; set; }
    }
}
