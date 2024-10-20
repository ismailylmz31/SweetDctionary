using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Models.Users;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Repository.Repositories.Concretes;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _businessRules;

        public UserService(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public ReturnModel<UserResponseDto> Add(CreateUserRequestDto dto)
        {            
            User createdUser = _mapper.Map<User>(dto);
            User user = _userRepository.Add(createdUser);
            UserResponseDto response = _mapper.Map<UserResponseDto>(user);
            return new ReturnModel<UserResponseDto> { Data = response, 
            Message = "Kullanıcı kaydı başarılı",
            Status =200,
            Success =true
            };
            
        }

        public ReturnModel<UserResponseDto> Delete(long id)
        {            
            _businessRules.IsPresent(id);
            User user = _userRepository.GetById(id);
            User deletedUser = _userRepository.Delete(user);
            return new ReturnModel<UserResponseDto>
            {
                Message = "Kullanıcı silindi!",
                Status=200,
                Success =true
                
            };

        }

        public ReturnModel<List<UserResponseDto>> GetAll()
        {            
            var users = _userRepository.GetAll();
            List<UserResponseDto> responses = _mapper.Map<List<UserResponseDto>>(users);
            return new ReturnModel<List<UserResponseDto>>
            {
                Data = responses,
                Success = true,
                Status = 200,
                Message = " Kullanııcılar Listelendi"

            };
        }

        public ReturnModel<UserResponseDto> GetById(long id)
        {
            try
            {
                _businessRules.IsPresent(id);
                var user = _userRepository.GetById(id);
                var response = _mapper.Map<UserResponseDto>(user);
                return new ReturnModel<UserResponseDto>
                {
                    Data = response,
                    Message = "seççilen id li kullanııcı ",
                    Status = 200,
                    Success = true
                };
            } catch (Exception ex) {
                return ExceptionHandler<UserResponseDto>.HandleException(ex);
            }
        }

        public ReturnModel<UserResponseDto> Update(UpdateUserRquestDto dto)
        {
           
            try
            {
                _businessRules.IsPresent(dto.Id);

                User user = _mapper.Map<User>(dto);
                User updated = _userRepository.Update(user);
                UserResponseDto response = _mapper.Map<UserResponseDto>(updated);
                return new ReturnModel<UserResponseDto>
                {
                    Data = response,
                    Success = true,
                    Status = 200,
                    Message = "KULLANICI GÜCNELLENDİ"
                };
            }
            catch (Exception ex) { return ExceptionHandler<UserResponseDto>.HandleException(ex); }

        }
    }
}
