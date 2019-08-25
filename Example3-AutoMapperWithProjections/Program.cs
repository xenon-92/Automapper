using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Example3_AutoMapperWithProjections
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthorModel authorModel = new AuthorModel();
            authorModel.Id = 002;
            authorModel.FirstName = "Bibhutibhushan";
            authorModel.LastName = "Bandyopadhyay";
            authorModel.City = "kolkata";
            authorModel.State = "West Bengal";
            authorModel.Country = "India";
            
            MapperConfiguration configuration = new MapperConfiguration(cfg=> 
            {
                cfg.CreateMap<AuthorModel, AuthorDTO>()
                .ForMember(dest => dest.AId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.FName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(
                       src => new Address
                       {
                           City = src.City,
                           State = src.State,
                           Country=src.Country                
                       }
                       ));
            });
            IMapper mapper = configuration.CreateMapper();
            var destination = mapper.Map<AuthorModel, AuthorDTO>(authorModel);
        }
    }
    class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    class AuthorModel
    {
        public int Id
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    class AuthorDTO
    {
        public int AId
        {
            get; set;
        }
        public string FName
        {
            get; set;
        }
        public string LName
        {
            get; set;
        }
        public int MyProperty { get; set; }

        public Address Address
        {
            get; set;
        }
    }
}
