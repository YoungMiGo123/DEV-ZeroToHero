﻿using ZeroToHero.BestPractices.TinyLink.Models;
using ZeroToHero.BestPractices.TinyLink.Models.Entities;

namespace ZeroToHero.BestPractices.TinyLink.Services
{
    public interface ITinyLinkService
    {
        Task<Link> CreateTinyLink(CreateTinyLinkCommand command);
        Task<string> GetOriginalLink(TinyLinkQuery query);
        Task RecordVisit(TinyLinkQuery query);
    }   
}
