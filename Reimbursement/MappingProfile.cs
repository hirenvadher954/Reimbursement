using System;
using AutoMapper;
using Entities.Models;
using Entities.Models.DataTransferObjects;
using Shared.DataTransferObjects;
using Shared.WorkerReimbursements;

namespace Reimbursement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkerReimbursement, WorkerReimbursementDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<PaymentItem, PaymentItemDTO>().ReverseMap();
        }
    }
}