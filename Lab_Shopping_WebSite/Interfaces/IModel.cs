using Lab_Shopping_WebSite.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Interfaces
{
    public class IModel
    {
        public DateTime ModifyTime { get; set; }

        public DateTime CreateTime { get; set; }
    }

}
