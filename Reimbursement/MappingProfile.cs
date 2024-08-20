using System;
using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Reimbursement
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<TestReimbursement, TestReimbursementDTO>()
				.ForMember(c => c.FullAddress,
				opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
			

			CreateMap<UserForRegistrationDTO, User>();
        }
	}
}

