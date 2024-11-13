using AutoMapper;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.DAL.Context;
using Infra.DAL.Concretes;
using Infra.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EGM.AracKiralama.DAL.Concretes
{
    public class AracKiralamaRepository : BaseRepository, IAracKiralamaRepository
    {
        private readonly AracKiralamaDbContext _context;
        private readonly IMapper _mapper;
        public AracKiralamaRepository(AracKiralamaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
