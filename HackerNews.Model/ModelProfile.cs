using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HackerNews.Model
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<HackerNewsItem, NewsItem>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.Uri, opt => opt.MapFrom(source => source.Url))
                .ForMember(dest => dest.PostedBy, opt => opt.MapFrom(source => source.By))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(source => DateTime.UnixEpoch.AddSeconds(source.Time)))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(source => source.Score))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(source => source.Descendants))
                .ReverseMap();
        }
    }
}
