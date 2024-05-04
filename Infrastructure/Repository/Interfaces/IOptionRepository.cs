﻿using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IOptionRepository
    {
        Task<Option> GetOptionByIdAsync(long optionId);
        Task<List<Option>> GetAllOptionsAsync();
        Task AddOptionAsync(Option option);
        Task UpdateOptionAsync(Option option);
        Task DeleteOptionAsync(long optionId);
    }
}
