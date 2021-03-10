using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        readonly ApplicationDbContext _context;
        readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context,IMapper mapper)
        {

            this._mapper = mapper;
            this._context=context;
        }

        public async Task<MemberDto> GetMemberAsync( string username)
        {
            return await _context.Users.Where(x=>x.Username==username).ProjectTo<MemberDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();


        }

        public async Task<AppUser> GetUserByIdAsync(int ID)
        {
            return await _context.Users.FindAsync(ID);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(p=>p.Photos).SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {

            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();

        }
    }
}
