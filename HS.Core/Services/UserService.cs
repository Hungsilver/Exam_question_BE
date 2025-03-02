using AutoMapper;
using AutoMapper.QueryableExtensions;
using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.DTOs.Response;
using Exam_question_BE.HS.Core.Entities;
using Exam_question_BE.HS.Core.Helpers;
using Exam_question_BE.HS.Core.Interfaces;
using Exam_question_BE.HS.Infrastructure.Data;
using Exam_question_BE.HS.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace Exam_question_BE.HS.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly string PASS_DEFAULT = "Admin@123";
        public UserService(ApplicationDBContext context, ILogger<UserService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<PaginatedList<UserDTORes>> GetFilter(int page, int pageSize, string search, string sort)
        {
            var query = _context.Users
                .Include(u => u.Roles)
                .ProjectTo<UserDTORes>(_mapper.ConfigurationProvider)
                .AsQueryable();

            Dictionary<string, string> keyValuePairsSearch = new Dictionary<string, string>()
            {
                {"Username",search},
                {"Code",search},
                {"Email",search},
                {"PhoneNumber",search},
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                //query = query.ApplyFilter("username", search);
                query = query.ApplyMultipleFilters(keyValuePairsSearch);
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                query = query.ApplySort(sort);
            }
            query = query.OrderBy(q => q.Id);

            return await PaginatedList<UserDTORes>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }
        public Task<IEnumerable<UserDTORes>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task<UserDTORes> GetOne(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserDTORes>(user);
        }
        public async Task<UserDTORes> Add(UserDTOReq userReq)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r=>r.Name=="USER");

            User user = _mapper.Map<User>(userReq);
            user.Id = Guid.Empty;
            user.Code = await GenerateCode.GenerateUniqueCodeAsync(_context);
            user.PasswordHash = PasswordService.HashPassword(PASS_DEFAULT);
            user.CreatedDate = DateTime.UtcNow;
            user.UpdatedDate = DateTime.UtcNow;
            user.Roles.Add(role);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTORes>(user);
        }
        public Task<UserDTORes> Update(Guid id, UserDTOReq user)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
