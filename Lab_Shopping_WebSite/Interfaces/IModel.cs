using AutoMapper;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab_Shopping_WebSite.Interfaces
{
    public class IModel
    {
        public IModel()
        {
        }
        [JsonIgnore]
        public DateTime? ModifyTime { get; set; }
        [JsonIgnore]

        public DateTime? CreateTime { get; set; }
    }
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
