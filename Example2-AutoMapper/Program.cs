using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Example2_AutoMapper
{/// <summary>
/// Here the property field does not match, i.e name of the property are not same 
/// as that of source and destination
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            AuthorModel _modelSource = new AuthorModel();
            _modelSource.AuthorId = 001;
            _modelSource.AuthorName = "Rabindranath Tagore";
            _modelSource.AuthorBook = "Gitanjali";
            MapperConfiguration configuration = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<AuthorModel, AuthorDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.Book, opts => opts.MapFrom(src => src.AuthorBook));
            });
            IMapper mapper = configuration.CreateMapper();
            var destination = mapper.Map<AuthorModel, AuthorDto>(_modelSource);
            /*for list*/
            List<AuthorModel> modelsList = new List<AuthorModel>
            {
                new AuthorModel{AuthorId=002,AuthorName="Anton Chekov",AuthorBook="Last Leaf"},
                new AuthorModel{AuthorId=003,AuthorName="Ruskin Bond",AuthorBook="Night Train At Deoli"},
                new AuthorModel{AuthorId=004,AuthorName="R K Narayan",AuthorBook="Malgudi days"},
                new AuthorModel{AuthorId=005,AuthorName="Amish Tripathi",AuthorBook="Mehula"},
            };
            var destinationList = mapper.Map<List<AuthorModel>, List<AuthorDto>>(modelsList);
        }
    }
    /// <summary>
    /// Source
    /// </summary>
    class AuthorModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBook { get; set; }
    }
    /// <summary>
    /// Destination
    /// </summary>
    class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Book { get; set; }
        public int AuthorPhoneNumber { get; set; }

    }
}
