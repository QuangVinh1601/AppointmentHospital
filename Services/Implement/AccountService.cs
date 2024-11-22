﻿using AppointmentHospital.Repositories;
using AppointmentHospital.Services;
using Microsoft.AspNetCore.Identity.Data;
using static AppointmentHospital.DTOs.Account.AccountRequest;

namespace AppointmentHospital.Services.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> LoginAsync(LoginUserRequest request)
        {
            var signInResult = await _accountRepository.LoginAsync(request);
            return signInResult;
        }


        public async Task<bool> RegisterAsync(RegisterUserRequest request)
        {
            return await _accountRepository.RegisterAsync(request);
        }
    }
}
