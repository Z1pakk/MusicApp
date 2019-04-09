using AutoMapper;
using MusicAppWith.Api.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MusicAppWithApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MusicModel, MusicViewModel>()
                            .ForMember(g => g.Id, t => t.MapFrom(c => c.id))
                            .ForMember(g => g.Name, t => t.MapFrom(c => c.name))
                            .ForMember(g => g.Image, t => t.MapFrom(c => c.image))
                            .ForMember(g => g.ReleaseDate, t => t.MapFrom(c => c.releasedate.ToString("dd MMMM yyyy")))
                            .ForMember(g => g.AlbumName, t => t.MapFrom(c => c.album_name))
                            .ForMember(g => g.ArtistName, t => t.MapFrom(c => c.artist_name))
                            .ForMember(g => g.Downloads, t => t.MapFrom(c => c.stats.rate_downloads_total))
                            .ForMember(g => g.Likes, t => t.MapFrom(c => c.stats.likes))
                            .ForMember(g => g.Dislikes, t => t.MapFrom(c => c.stats.dislikes))
                            .ForMember(g => g.DownloadLink, t => t.MapFrom(c => c.audiodownload))
                            .ForMember(g => g.ListenUrl, t => t.MapFrom(c => c.shorturl));
                cfg.CreateMap<JsonHeader, OtherInfo>()
                            .ForMember(g => g.CountMusics, t => t.MapFrom(c => c.results_fullcount));
            });
        }
    }
}
