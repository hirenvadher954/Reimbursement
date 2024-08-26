using System;
using AutoMapper;
using Entities.Models;
using Entities.Models.DataTransferObjects;
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

			CreateMap<WorkerReimbursement, WorkerReimbursementDTO>().ReverseMap();
			CreateMap<Payment, PaymentDTO>().ReverseMap();
			CreateMap<PaymentItem, PaymentItemDTO>().ReverseMap();
			

			CreateMap<UserForRegistrationDTO, User>();
        }
	}
}

